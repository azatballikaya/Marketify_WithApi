using Marketify.Business.Abstract;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Marketify.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ChatController : ControllerBase
    {
        private readonly IChatService _chatService;

        public ChatController(IChatService chatService)
        {
            _chatService = chatService;
        }
        [HttpGet("GetChatByUserId/{id}")]
        public async Task<IActionResult> GetChatByUserId(string id)
        {
            var response=await _chatService.GetUserChatsAsync(id);
            IActionResult result = response.IsSuccess ? Ok(response.Data) : BadRequest();
            return result;
        }
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteChat(int id)
        {
            var response = await _chatService.DeleteChatAsync(id);
            IActionResult result = response.IsSuccess ? Ok() : BadRequest();
            return result;
        }
    }
}
