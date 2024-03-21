using AutoMapper;
using Marketify.Business.Abstract;
using Marketify.Business.DTOs.ChatDTOs;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace Marketify.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ChatController : ControllerBase
    {
        private readonly IChatService _chatService;
        private readonly IMapper _mapper;

        public ChatController(IChatService chatService, IMapper mapper)
        {
            _chatService = chatService;
            _mapper = mapper;
        }
        [HttpGet("GetChatByUserId/{id}")]
        public async Task<IActionResult> GetChatByUserId(string id)
        {
            
            var response=await _chatService.GetUserChatsAsync(id);
            
            var chatJson=JsonConvert.SerializeObject(response.Data,Formatting.Indented,new JsonSerializerSettings
            {
                ReferenceLoopHandling = ReferenceLoopHandling.Ignore,
            });
            IActionResult result = response.IsSuccess ? Ok(chatJson) : BadRequest();
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
