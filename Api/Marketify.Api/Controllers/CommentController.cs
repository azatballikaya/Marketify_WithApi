using AutoMapper;
using Marketify.Business.Abstract;
using Marketify.Business.DTOs.CommentDTOs;
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
        private readonly IMapper _mapper;

        public CommentController(ICommentService commentService, IMapper mapper)
        {
            _commentService = commentService;
            _mapper = mapper;
        }

        [HttpPost]
        public async Task<IActionResult> CreateComment(CreateCommentDTO createCommentDTO)
        {
            var comment=_mapper.Map<Comment>(createCommentDTO);
            var response= await _commentService.CreateCommentAsync(comment);
            IActionResult result = response.IsSuccess ? Ok() : BadRequest();
            return result;
        }
        [HttpDelete]
        public async Task<IActionResult> DeleteComment(int id)
        {
            var response=await _commentService.DeleteCommentAsync(id);
            IActionResult result=response.IsSuccess ? Ok(response) : BadRequest();
            return result;
        }
    }
}
