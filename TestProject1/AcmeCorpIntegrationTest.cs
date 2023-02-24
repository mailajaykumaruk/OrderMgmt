using AcmeCorpTesting.Models;
using Microsoft.AspNetCore.Mvc.Testing;

using System.Net;
using System.Net.Http.Json;
using System.Text.Json;

namespace AcmeCorpTesting
{
    public class AcmeCorpIntegrationTest 
    {
        private readonly HttpClient _httpClient;        

        public AcmeCorpIntegrationTest()
        {            
            var appFactory = new WebApplicationFactory<Program>();
            _httpClient = appFactory.CreateClient();
            _httpClient.DefaultRequestHeaders.Add("x-api-key", Helpers.Helper.GetApiKey());
        }

        //Customer Integration testing
        [Fact]
        public async void CreateCustomer_WhenNew_ReturnCustId() 
        {
            //Arrange            
            var customer = new Customer
            {
                Name = "Ajay",
                Address = "Eltham Road",
                City = "asd",
                IsActive = true,
                LastUpdatedOn = DateTime.Now,
                State = "London",
                ZipCode = "123"
            };

            //Act
            var  response = await _httpClient.PostAsJsonAsync(ApiTestingRoutes.Customer.Create,customer);
            
            //Assert
            var cust = await response.Content.ReadFromJsonAsync<Customer>();            
            Assert.Equal(1, cust.Id);            

        }


        [Fact]
        public async void GetCustomer_WhenCustNotExisting_ReturnNull()
        {
            //Arrange            
            long customerId = 101;
            string uri = ApiTestingRoutes.Customer.Get + "?customerId=" + customerId;

            //Act
            var response = await _httpClient.GetFromJsonAsync<Customer>(uri);

            //Assert            
            Assert.Null(response);
        }


        //CustomerOrder Integration testing
        [Fact]
        public async void CreateCustomerOrder_WhenNew_ReturnOrderId()
        {
            //Arrange            
            var order = new CustomerOrder
            {
               CustomerId=1,
               DeliveryDate= DateTime.Now,
               ItemId=1,
               OrderDate= DateTime.Now,
               ItemPrice= 100,
               LastUpdatedOn= DateTime.Now,
               Quantity=1,
               Status=1
            };

            //Act
            var response = await _httpClient.PostAsJsonAsync(ApiTestingRoutes.CusomerOrder.Create, order);

            //Assert
            var custOrder = await response.Content.ReadFromJsonAsync<CustomerOrder>();
            Assert.Equal(1, custOrder.Id);
        }

        [Fact]
        public async void GetCustomerOrder_WhenCustOrderNotExisting_ReturnNull()
        {
            //Arrange            
            long customerId = 101;
            string uri = ApiTestingRoutes.CusomerOrder.Get + "?customerId=" + customerId;

            //Act
            var response = await _httpClient.GetFromJsonAsync<CustomerOrder>(uri);

            //Assert            
            Assert.Null(response);
        }


        // CusomterContactInfo intergration testing
        [Fact]
        public async void CreateCustomerContactInfo_WhenNew_ReturnContactInfoId()
        {
            //Arrange            
            var contactInfo = new CustomerContactInfo
            {
                CustomerId = 1,
                Email = "abc@train.com",
                IsActive=true,
                LastUpdatedOn = DateTime.Now,
                PhoneNumber= "1234567890"                
            };

            //Act
            var response = await _httpClient.PostAsJsonAsync(ApiTestingRoutes.CustomerContactInfo.Create, contactInfo);

            //Assert
            var contactInfoSaved = await response.Content.ReadFromJsonAsync<CustomerContactInfo>();
            Assert.Equal(1, contactInfoSaved.Id);
        }

        [Fact]
        public async void GetCustomerContactInfo_WhenContactInfoNotExisting_ReturnNull()
        {
            //Arrange            
            long customerId = 200;
            string uri = ApiTestingRoutes.CustomerContactInfo.Get + "?customerId=" + customerId;

            //Act
            var response = await _httpClient.GetFromJsonAsync<CustomerContactInfo>(uri);

            //Assert            
            Assert.Null(response);
        }

    }
}