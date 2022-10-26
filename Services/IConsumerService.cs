using ApacheKafkaConsumerDemo.Models;

namespace ApacheKafkaConsumerDemo.Services
{
   
    public interface IConsumerService
    {
        Task<IEnumerable<OrderProcessingRequest>> Start();
        Task Stop();
    }
}
