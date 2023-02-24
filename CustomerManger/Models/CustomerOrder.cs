namespace AcmeCorpTesting.Models
{
    public class CustomerOrder
    {
        public int Id { get; set; }
        public long CustomerId { get; set; }
        public DateTime OrderDate { get; set; }
        public DateTime DeliveryDate { get; set; }
        public long ItemId { get; set; }

        public double ItemPrice { get; set; }
        public int Status { get; set; }
        public int Quantity { get; set; }
        public DateTime LastUpdatedOn { get; set; }
    }
}
