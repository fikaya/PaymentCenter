using Microsoft.AspNetCore.Mvc;
using PaymentCenter.BusinessLayer.Abstract;
using PaymentCenter.BusinessLayer.Concrete;
using PaymentCenter.Entities;
using System;
using System.Linq;

namespace PaymentCenter.WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SubscriberController : Controller
    {
        private IService<Subscriber> _service;
        private IService<Invoice> _invoiceService;
        private IService<InstitutionSubscriber> _institutionSubscriberService;

        public SubscriberController(
            IService<Subscriber> service,
            IService<Invoice> invoiceService,
            IService<InstitutionSubscriber> institutionSubscriber
            )
        {
            _service = service;
            _invoiceService = invoiceService;
            _institutionSubscriberService = institutionSubscriber;
        }

        /// <summary>
        /// Abone  Kapatma İşlemlerini Buradan Yapabiliriz.
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet]
        [Route("GetSubscriberByID/{id}")]
        public IActionResult Get(Guid id)
        {
            var institutionSubscriber = _institutionSubscriberService.GetReference(x => x.SubscriberRegistrationNumber == id, "Subscriber", "Institution").FirstOrDefault();

            var list = _institutionSubscriberService.GetCollection(x => x.SubscriberRegistrationNumber == id, "Invoices");

            if (institutionSubscriber != null && institutionSubscriber.Invoices != null)
            {
                foreach (var item in list)
                {
                    if (item.IsActive == false)
                    {
                        return BadRequest("Ödenmemiş Fatura Bulunduğu İçin Abone İptali Yapılamıyor.");
                    }
                }

                institutionSubscriber.DepositAmount = 0;
                institutionSubscriber.IsActive = false;
                _institutionSubscriberService.Update(institutionSubscriber);

                return Ok(institutionSubscriber);//200+data
            }
            return NotFound();//404
        }

        /// <summary>
        ///  Buradan Abone Ekleyebiliriz.
        /// </summary>
        /// <param name="institutionSubscriberService"></param>
        /// <returns></returns>
        [HttpPost]
        [Route("[action]")]
        public IActionResult Create([FromBody] Subscriber subscriber)
        {
            if (ModelState.IsValid)
            {
                var affectedRows = _service.Insert(subscriber);
                if (affectedRows > 0)
                {
                    return Ok(subscriber);
                }
                else
                {
                    return BadRequest("Herhangi Bir Kayıt İşlemi Gerçekleşmedi.");
                }
            }

            return BadRequest(ModelState);//400 + Validation Errors
        }
    }
}
