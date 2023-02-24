using AcmeCorpTesting.Models;

namespace AcmeCorpTesting.Interfaces
{
    public interface IManageCustomer
    {
        Customer CreateCustomer(Customer customer);
        Boolean DeleteCustomer(long customerId);
        Customer? UpdateCustomer(Customer customer);
        Customer? GetCustomer(long customerId);
    }
}
