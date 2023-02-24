using AcmeCorpTesting.Models;

namespace AcmeCorpTesting.Interfaces
{
    public interface IManageCustomerContactInfo
    {
        CustomerContactInfo CreateCustomerContactInfo(CustomerContactInfo contactInfo);
        Boolean DeleteCustomerContactInfo(long customerId);
        CustomerContactInfo? UpdateCustomerContactInfo(CustomerContactInfo contactInfo);
        CustomerContactInfo GetCustomerContactInfo(long customerId);

    }
}
