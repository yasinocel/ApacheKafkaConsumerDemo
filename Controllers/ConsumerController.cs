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
        [Route("start-consume")]
        public async Task<IActionResult> Start()
        {
            return Ok(await _consumerService.Start());
        }
    }
}
