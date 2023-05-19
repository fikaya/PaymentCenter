using Microsoft.AspNetCore.Mvc;
using PaymentCenter.BusinessLayer.Abstract;
using PaymentCenter.Entities;
using System;
using System.ComponentModel;
using System.Linq;

namespace PaymentCenter.WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class InstitutionSubscriberController : Controller
    {
        private IService<InstitutionSubscriber> _service;
        private IInstitutionSubscriberService<InstitutionSubscriber> _institutionSubscriberService;

        public InstitutionSubscriberController(
            IService<InstitutionSubscriber> service,
            IInstitutionSubscriberService<InstitutionSubscriber> institutionSubscriberService
            )
        {
            _service = service;
            _institutionSubscriberService = institutionSubscriberService;
        }

        /// <summary>
        /// Abone Sicil Numarası İle İlgili Kişiyi Arayarak Elde Edebiliriz.
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [Route("GetSubscriberByID/{id}")]
        public IActionResult Get(Guid id)
        {
            var institutionSubscriber = _service.GetReference(x => x.SubscriberRegistrationNumber == id, "Subscriber", "Institution").FirstOrDefault();

            if (institutionSubscriber != null)
            {
                return Ok(institutionSubscriber);//200+data
            }
            return NotFound();//404
        }

        /// <summary>
        /// Herhangi Bir Kuruma Abone Oluşturabiliriz.Ama Buradan Önce Abone Tablosuna O Kişiyi Eklemeliyiz.
        /// </summary>
        /// <param name="institutionSubscriberService"></param>
        /// <returns></returns>
        [HttpPost]
        [Route("[action]")]
        public IActionResult Create([FromBody] InstitutionSubscriber institutionSubscriberService)
        {
            if (ModelState.IsValid)
            {
                var affectedRows = _service.Insert(institutionSubscriberService);
                if (affectedRows > 0)
                {
                    return Ok(institutionSubscriberService);
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
