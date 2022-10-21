using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Rabbit.Model.Entities;
using Rabbit.Services.Interfaces;

namespace Rabbit.Publisher.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RabbitMessagesController : ControllerBase
    {
        private readonly IRabbitMessageService _rabbitMessageService;

        public RabbitMessagesController(IRabbitMessageService rabbitMessageService)
        {
            _rabbitMessageService = rabbitMessageService;
        }

        [HttpPost]
        public void AddMessage(RabbitMessage message)
        {
            _rabbitMessageService.SendMessage(message);
        }
    }
}
