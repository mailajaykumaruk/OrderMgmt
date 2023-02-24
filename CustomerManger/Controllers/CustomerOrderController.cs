using AcmeCorpTesting.Interfaces;
using AcmeCorpTesting.Models;
using AcmeCorpTesting.Processor;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace AcmeCorpTesting.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class CustomerOrderController : ControllerBase
    {
        private readonly IManageCustomerOrder _order;
        public CustomerOrderController(CustomerOrderProcessor orderProcessor, ApiContext context)
        {
            orderProcessor.SetApiContext(context);
            _order= orderProcessor;
        }

        [HttpPost]
        public JsonResult CreateCustomerOrder(CustomerOrder customerOrder)
        {
            var  orderInDb= _order.CreateCustomerOrder(customerOrder);
            return new JsonResult(orderInDb);
        }

        [HttpDelete]
        public JsonResult CancelCustomerOrder(long orderId)
        {
            var isCancelled = _order.CancelCustomerOrder(orderId);

            if (!isCancelled)
                return new JsonResult(NotFound());
            else
                return new JsonResult(Ok());
        }

        [HttpPut]
        public JsonResult UpdateCustomerOrder(CustomerOrder customerOrder)
        {
            var orderInDb = _order.UpdateCustomerOrder(customerOrder);
            return new JsonResult(orderInDb);
        }

        [HttpGet]
        public JsonResult GetCustomerOrder(long customerId)
        {
            var orderInDb = _order.GetCustomerOrder(customerId);
            return new JsonResult(orderInDb);
        }


    }
}
