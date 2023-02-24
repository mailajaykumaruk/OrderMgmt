using AcmeCorpTesting.Interfaces;
using AcmeCorpTesting.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace AcmeCorpTesting.Processor
{
    public class CustomerProcessor : IManageCustomer
    {
        public ApiContext _context;

        public void SetApiContext(ApiContext context)
        {
            _context = context;
        }
               

        public Customer CreateCustomer(Customer customer)
        {            
            _context.Customers.Add(customer);
            _context.SaveChanges();
            return customer;
        }

        public bool DeleteCustomer(long customerId)
        {
            var customerInDb = _context.Customers.Find(customerId);

            if (customerInDb != null)
            {
                _context.Customers.Remove(customerInDb);
                _context.SaveChanges();
                return true;
            }

            return false;   
        }

        public Customer? UpdateCustomer(Customer customer)
        {
            var customerInDb = _context.Customers.Find(customer.Id);
            if (customerInDb == null)
                return customerInDb;

            customerInDb = customer;            
            _context.SaveChanges();
            return customer;
        }

        public Customer? GetCustomer(long customerId)
        {
            var customerInDb = _context.Customers.Find(customerId);            
            return customerInDb;
        }
    }
}
