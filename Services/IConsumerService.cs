using ApacheKafkaConsumerDemo.Models;

namespace ApacheKafkaConsumerDemo.Services
{
   
    public interface IConsumerService
    {
        Task<IEnumerable<OrderProcessingRequest>> Consume();
        Task Stop();
    }
}
