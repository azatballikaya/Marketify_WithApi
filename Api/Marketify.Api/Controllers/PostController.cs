using AutoMapper;
using Marketify.Business.Abstract;
using Marketify.Business.DTOs.PostDTOs;
using Marketify.Entity;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Marketify.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PostController : ControllerBase
    {
        private readonly IPostService _postService;
        private readonly IMapper _mapper;

        public PostController(IPostService postService, IMapper mapper)
        {
            _postService = postService;
            _mapper = mapper;
        }
        [HttpGet]
        public async Task<IActionResult> GetAllPosts()
        {
            var response=await _postService.GetAllPostsAsync();
            IActionResult result = response.IsSuccess ? Ok(response.Data) : BadRequest();
            return result;
        }
        [HttpGet("{id}")]
        public async Task<IActionResult> GetPostById(int id)
        {
            var response = await _postService.GetPostByIdAsync(id);
            IActionResult result = response.IsSuccess ? Ok(response.Data) : BadRequest();
            return result;
        }
        [HttpPost]
        public async Task<IActionResult> CreatePost(CreatePostDTO createPostDTO)
        {
            var post = _mapper.Map<Post>(createPostDTO);
            var response= await _postService.CreatePostAsync(post);
            IActionResult result = response.IsSuccess ? Ok() : BadRequest();
            return result;
        }
        [HttpPut]
        public async Task<IActionResult> UpdatePost(UpdatePostDTO updatePostDTO)
        {
            var post=_mapper.Map<Post>(updatePostDTO);
            var response=await _postService.UpdatePostAsync(post);
            IActionResult result = response.IsSuccess ? Ok() : BadRequest();
            return result;
        }
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeletePost(int id)
        {
            var response=await _postService.DeletePostAsync(id);
            IActionResult result=response.IsSuccess ? Ok() : NotFound();
            return result;
        }
    }
}
