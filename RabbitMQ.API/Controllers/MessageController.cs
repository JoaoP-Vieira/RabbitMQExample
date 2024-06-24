using Microsoft.AspNetCore.Mvc;
using RabbitMQ.API.Data;

namespace RabbitMQ.API.Controllers
{
    public class MessageBody
    { 
        public string Message { get; set; } = string.Empty;
    }

    [ApiController]
    [Route("v1/message")]
    public class MessageController : ControllerBase
    {
        private readonly ILogger<MessageController> _logger;
        private readonly IMessageProducer _producer;

        public MessageController(ILogger<MessageController> logger, IMessageProducer producer)
        {
            _logger = logger;
            _producer = producer;
        }

        [HttpPost]
        public IActionResult Send([FromBody] MessageBody body)
        {
            try
            {
                _producer.SendMessage(body.Message);

                return Ok("done");
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
