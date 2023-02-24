using AcmeCorpTesting.Controllers;
using AcmeCorpTesting.Models;

namespace AcmeCorpTesting.Interfaces
{
    public interface IManageCustomerOrder
    {
        CustomerOrder CreateCustomerOrder(CustomerOrder customerOrder);
        CustomerOrder? UpdateCustomerOrder(CustomerOrder customerOrder);
        Boolean  CancelCustomerOrder(long orderId);
        CustomerOrder? GetCustomerOrder(long customerId);
    }
}
