using Microsoft.EntityFrameworkCore;

namespace AcmeCorpTesting.Models
{
    public class ApiContext : DbContext
    {
        public DbSet<Customer> Customers { get; set; }

        public DbSet<CustomerContactInfo> CustomersContactInfo { get; set; }

        public DbSet<CustomerOrder> CustomersOrders { get; set; }
        
        public ApiContext(DbContextOptions<ApiContext> options) :base(options)
        {           
        }

    }
}
