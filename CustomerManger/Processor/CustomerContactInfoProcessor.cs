using AcmeCorpTesting.Interfaces;
using AcmeCorpTesting.Models;

namespace AcmeCorpTesting.Processor
{
    public class CustomerContactInfoProcessor : IManageCustomerContactInfo
    {
        public ApiContext _context;
           public void SetApiContext(ApiContext context)
        {
            _context = context;
        }

        public CustomerContactInfo CreateCustomerContactInfo(CustomerContactInfo contactInfo)
        {
            _context.CustomersContactInfo.Add(contactInfo);
            _context.SaveChanges();
            return contactInfo;
        }

        public bool DeleteCustomerContactInfo(long customerId)
        {
            var customersContactInfoInDb = _context.CustomersContactInfo.Find(customerId);

            if (customersContactInfoInDb != null)
            {
                _context.CustomersContactInfo.Remove(customersContactInfoInDb);
                _context.SaveChanges();
                return true;
            }

            return false;
        }
             

        public CustomerContactInfo? UpdateCustomerContactInfo(CustomerContactInfo contactInfo)
        {
            var contactInfoInDb = _context.CustomersContactInfo.Find(contactInfo.Id);
            if (contactInfoInDb == null)
                return contactInfoInDb;

            contactInfoInDb = contactInfo;            
            _context.SaveChanges();
            return contactInfo;
        }


        public CustomerContactInfo GetCustomerContactInfo(long customerId)
        {
            var contactInfosInDb = _context.CustomersContactInfo.Where(info =>  info.CustomerId == customerId).FirstOrDefault();
            return contactInfosInDb;
        }
    }
}
