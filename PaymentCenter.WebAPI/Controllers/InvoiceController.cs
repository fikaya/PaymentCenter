using Microsoft.AspNetCore.Mvc;
using PaymentCenter.BusinessLayer.Abstract;
using PaymentCenter.Entities;
using System;
using System.Collections.Generic;
using System.Linq;

namespace PaymentCenter.WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class InvoiceController : Controller
    {
        private IService<InstitutionSubscriber> _service;
        private IService<BoxOfficeAttendant> _boxOfficeAttendantService;
        private IService<Invoice> _invoiceService;
        private IInstitutionSubscriberService<InstitutionSubscriber> _institutionSubscriberService;

        public InvoiceController(
            IService<InstitutionSubscriber> service,
            IService<Invoice> invoiceService,
            IService<BoxOfficeAttendant> boxOfficeAttendantService,
            IInstitutionSubscriberService<InstitutionSubscriber> institutionSubscriberService
            )
        {
            _service = service;
            _invoiceService = invoiceService;
            _institutionSubscriberService = institutionSubscriberService;
            _boxOfficeAttendantService = boxOfficeAttendantService;
        }

        /// <summary>
        /// Abone Sicil Numarası İle İlgili Kişiyi Arayarak Faturasını Ödeyebiliriz. Ardından Faturayı Döndüreceğiz.
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [Route("GetSubscriberByInvoiceID/{id}/{invoiceId}/{boxOfficeAttendantId}")]
        public IActionResult Get(Guid id, int invoiceId, int boxOfficeAttendantId)
        {
            var boxOfficeAttendant = _boxOfficeAttendantService.Find(x => x.ID == boxOfficeAttendantId);

            var invoice = _invoiceService.Find(x => x.ID == invoiceId);

            if (boxOfficeAttendant == null)
            {
                return BadRequest("Böyle Bir Görevli Kayıtlı Değil.");
            }
            else if (invoice == null)
            {
                return BadRequest("Böyle Bir Fatura Kayıtlı Değil.");
            }
            else
            {
                var institutionSubscribers = _service.GetReference(x => x.SubscriberRegistrationNumber == id, "Subscriber", "Institution").FirstOrDefault();

                _service.GetCollection(x => x.SubscriberID == institutionSubscribers.SubscriberID, "Invoices");

                foreach (var invoiceItem in institutionSubscribers.Invoices)
                {
                    if (id == institutionSubscribers.SubscriberRegistrationNumber && invoiceItem.IsActive == false)
                    {
                        invoice.IsActive = true;
                        invoice.PaymentDate = DateTime.Now;
                        invoice.BoxOfficeAttendantID = boxOfficeAttendantId;
                        _invoiceService.Update(invoice);
                        return Ok(invoice);//200+data
                    }
                }
                return BadRequest("Ödenmemiş Faturanız Bulunmamaktadır.");
            }
        }

        /// <summary>
        /// Eğer True Değer Gönderilirse Ödenmişler,False Değer Gönderilirse Ödenmemişler Döner.
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [Route("GetSubscriberByInvoiceStation/{id}/{value}")]
        public IActionResult Get(int id, bool value)
        {
            var institutionSubscribers = _service.GetReference(x => x.SubscriberID == id, "Subscriber", "Institution");
            _service.GetCollection(x => x.SubscriberID == id, "Invoices");

            var list = new List<Invoice>();

            foreach (var item in institutionSubscribers)
            {
                foreach (var itemInvoice in item.Invoices)
                {
                    if (itemInvoice.IsActive == value)
                    {
                        list.Add(itemInvoice);
                    }
                }
            }
            if (list.Count == 0)
            {
                if (value)
                {
                    return BadRequest("Ödenmiş Faturanız Bulunmamaktadır.");
                }
                else
                {
                    return BadRequest("Ödenmemiş Faturanız Bulunmamaktadır.");

                }
            }
            return Ok(list);//200+data
        }
    }
}
