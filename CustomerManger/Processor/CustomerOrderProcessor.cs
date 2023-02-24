using AcmeCorpTesting.Interfaces;
using AcmeCorpTesting.Models;
using Microsoft.AspNetCore.Mvc;

namespace AcmeCorpTesting.Processor
{
    public class CustomerOrderProcessor : IManageCustomerOrder
    {
        public ApiContext _context;
        public void SetApiContext(ApiContext context)
        {
            _context = context;
        }

        
        public CustomerOrder CreateCustomerOrder(CustomerOrder customerOrder)
        {
            _context.CustomersOrders.Add(customerOrder);
            _context.SaveChanges();
            return customerOrder;
        }

        
        public bool CancelCustomerOrder(long orderId)
        {
            var orderInDb = _context.CustomersOrders.Find(orderId);
            if (orderInDb != null)
            {
                _context.CustomersOrders.Remove(orderInDb);
                _context.SaveChanges();
                return true;
            }else
                return false;
        }

        
        public CustomerOrder UpdateCustomerOrder(CustomerOrder customerOrder)
        {           
            var orderInDb = _context.CustomersOrders.Find(customerOrder.Id);
            if (orderInDb == null)
                return customerOrder;

            orderInDb = customerOrder;            
            _context.SaveChanges();

            return customerOrder;
        }

        
        public CustomerOrder? GetCustomerOrder(long customerId)
        {
            var contactOrderInDb = _context.CustomersOrders.Where(info => info.CustomerId == customerId).FirstOrDefault();
            return contactOrderInDb;

        }
    }
}
