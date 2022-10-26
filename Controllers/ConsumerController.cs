using ApacheKafkaConsumerDemo.Services;
using Microsoft.AspNetCore.Mvc;

namespace ApacheKafkaConsumerDemo.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ConsumerController : Controller
    {
        private readonly IConsumerService _consumerService;

        public ConsumerController(IConsumerService consumerService)
        {
            _consumerService = consumerService;
        }


        [HttpGet]
        [Route("consume")]
        public async Task<IActionResult> Consume()
        {
            return Ok(await _consumerService.Consume());
        }
    }
}
