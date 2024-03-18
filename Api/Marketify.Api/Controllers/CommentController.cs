using Marketify.Business.Abstract;
using Marketify.Entity;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Marketify.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CommentController : ControllerBase
    {
        private readonly ICommentService _commentService;

        public CommentController(ICommentService commentService)
        {
            _commentService = commentService;
        }

        [HttpPost]
        public async Task<IActionResult> CreateComment(Comment comment)
        {
            var response= await _commentService.CreateCommentAsync(comment);
            IActionResult result = response.IsSuccess ? Ok(comment) : BadRequest();
            return result;
        }
        [HttpGet]
        public async Task<IActionResult> DeleteComment(int id)
        {
            var response=await _commentService.DeleteCommentAsync(id);
            IActionResult result=response.IsSuccess ? Ok(response) : BadRequest();
            return result;
        }
    }
}
