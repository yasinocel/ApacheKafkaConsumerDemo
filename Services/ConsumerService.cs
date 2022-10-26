using ApacheKafkaConsumerDemo.Models;
using Confluent.Kafka;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;
using System.Diagnostics;
using System.Text.Json;

namespace ApacheKafkaConsumerDemo.Services
{
    public class ConsumerService : IConsumerService
    {
        private readonly string _topic = "testtopic1";
        private readonly string _groupId = "test_group";
        private readonly string _bootstrapServers = "localhost:9092";



        public Task<IEnumerable<OrderProcessingRequest>> Consume()
        {
            var messages = new List<OrderProcessingRequest>();

            var config = new ConsumerConfig
            {
                GroupId = _groupId,
                BootstrapServers = _bootstrapServers,
                AutoOffsetReset = AutoOffsetReset.Earliest
            };

            try
            {


                using (var consumerBuilder = new ConsumerBuilder<Ignore, string>(config).Build())
                {
                    consumerBuilder.Subscribe(_topic);

                    try
                    {
                        //while (true)
                        //{
                        var consumer = consumerBuilder.Consume(TimeSpan.FromSeconds(30));

                        if (consumer != null)
                        {
                            var orderRequest = JsonSerializer.Deserialize<OrderProcessingRequest>(consumer.Message.Value);
                            messages.Add(orderRequest);
                        }
                        //}



                    }
                    catch (OperationCanceledException)
                    {
                        consumerBuilder.Close();
                    }
                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex.Message);
            }

            return Task.FromResult(messages.AsEnumerable());
        }

        public Task Stop()
        {
            //....

            return Task.CompletedTask;
        }
    }
}
