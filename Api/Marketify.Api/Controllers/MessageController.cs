using Marketify.Business.Abstract;
using Marketify.Business.DTOs.MessageDTOs;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Marketify.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MessageController : ControllerBase
    {
        private readonly IMessageService _messageService;

        public MessageController(IMessageService messageService)
        {
            _messageService = messageService;
        }
        [HttpPost]
        public async Task<IActionResult> CreateMessage(CreateMessageDTO createMessageDTO)
        {
            var response=await _messageService.CreateMessageAsync(createMessageDTO);
            IActionResult result = response.IsSuccess ? Ok() : BadRequest();
            return result;
        }
    }
}
