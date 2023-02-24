using AcmeCorpTesting.Models;
using AcmeCorpTesting.Interfaces;
using Microsoft.AspNetCore.Mvc;
using AcmeCorpTesting.Processor;

namespace AcmeCorpTesting.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class CustomerController : ControllerBase
    {        
        private readonly IManageCustomer _manageCustomer;
        
        public CustomerController(CustomerProcessor manageCustomer, ApiContext apiContext)
        {            
            manageCustomer.SetApiContext(apiContext);
            this._manageCustomer = manageCustomer;   
        }

        [HttpPost]
        public JsonResult CreateCustomer(Customer customer)
        {
            var customerInDb = _manageCustomer.CreateCustomer(customer);            
            return new JsonResult(customerInDb);            
        }

        [HttpDelete]
        public JsonResult DeleteCustomer(long customerId) {
            var isDeleted = _manageCustomer.DeleteCustomer(customerId);                      

            if (!isDeleted)
                return new JsonResult(NotFound()); 
            else 
                return new JsonResult(Ok());        
        }

        [HttpPut]
        public JsonResult UpdateCustomer(Customer customer) {
            var customerInDb = _manageCustomer.CreateCustomer(customer);

            if(customerInDb == null) { 
                return new JsonResult(NotFound());
            }

            return new JsonResult(customerInDb);
        }

        [HttpGet]
        public JsonResult  GetCustomer(long customerId)
        {
            var customerInDb = _manageCustomer.GetCustomer(customerId);
            return new JsonResult(customerInDb);
        }
    }
}
