using AcmeCorpTesting.Interfaces;
using AcmeCorpTesting.Models;
using AcmeCorpTesting.Processor;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace AcmeCorpTesting.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class CustomerContactInfoController : ControllerBase
    {
        private readonly IManageCustomerContactInfo _contactInfo;

        public CustomerContactInfoController(CustomerContactInfoProcessor contactInfo, ApiContext apiContext)
        {
            contactInfo.SetApiContext(apiContext);
            _contactInfo = contactInfo;

        }

        [HttpPost]
        public JsonResult CreateCustomerContactInfo(CustomerContactInfo contactInfo)
        {
            var contactInfoInDb = _contactInfo.CreateCustomerContactInfo(contactInfo);
            return new JsonResult(contactInfoInDb);
        }

        [HttpDelete]
        public JsonResult DeleteCustomerInfo(long customerId)
        {
            var isDeleted = _contactInfo.DeleteCustomerContactInfo(customerId);

            if (!isDeleted)
                return new JsonResult(NotFound());
            else
                return new JsonResult(Ok(null));
        }

        [HttpPut]
        public JsonResult UpdateCustomerContactInfo(CustomerContactInfo contactInfo)
        {
            var contactInfoInDb = _contactInfo.UpdateCustomerContactInfo(contactInfo);
            if (contactInfoInDb == null)
                return new JsonResult(NotFound());
            else
                return new JsonResult(contactInfoInDb);
        }

        [HttpGet]
        public JsonResult GetCustomerContactInfo(long customerId)
        {
            var contactInfoInDb = _contactInfo.GetCustomerContactInfo(customerId);
            return new JsonResult(contactInfoInDb);

        }

    }
}
