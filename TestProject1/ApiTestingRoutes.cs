using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AcmeCorpTesting
{
    public class ApiTestingRoutes
    { 
        public static class CusomerOrder
        {
            public const string Create = "/api/CustomerOrder/CreateCustomerOrder";
            public const string Delete = "/api/CustomerOrder/CancelCustomerOrder";
            public const string Update = "/api/CustomerOrder/UpdateCustomerOrder";
            public const string Get = "/api/CustomerOrder/GetCustomerOrder";
        }

        public static class Customer
        {
            public const string Create = "/api/Customer/CreateCustomer";
            public const string Delete = "/api/Customer/DeleteCustomer";
            public const string Update = "/api/Customer/UpdateCustomer";
            public const string Get = "/api/Customer/GetCustomer";
        }

        public static class CustomerContactInfo {
            public const string Create = "/api/CustomerContactInfo/CreateCustomerContactInfo";
            public const string Delete = "/api/CustomerContactInfo/DeleteCustomerInfo";
            public const string Update = "/api/CustomerContactInfo/UpdateCustomerContactInfo";
            public const string Get = "/api/CustomerContactInfo/GetCustomerContactInfo";

        }
    }      
        
}
