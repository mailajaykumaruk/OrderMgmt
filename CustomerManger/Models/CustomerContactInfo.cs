namespace AcmeCorpTesting.Models
{
    public class CustomerContactInfo
    {
        public long Id { get; set; }
        public long CustomerId { get; set; }
        public string? Email { get; set; }
        public string? PhoneNumber { get; set; }
        public Boolean IsActive { get; set; }
        public DateTime LastUpdatedOn { get; set; }

    }
}
