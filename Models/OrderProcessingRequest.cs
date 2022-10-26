namespace ApacheKafkaConsumerDemo.Models
{
    public class OrderProcessingRequest
    {
        public int OrderId { get; set; }
        public string CustomerName { get; set; }
        public string ProductName { get; set; }
        public int Quantity { get; set; }
        public string Status { get; set; }
    }
}
