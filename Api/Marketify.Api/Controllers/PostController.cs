using AutoMapper;
using Marketify.Business.Abstract;
using Marketify.Business.DTOs.LikeDTOs;
using Marketify.Business.DTOs.PostDTOs;
using Marketify.Entity;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Text.Json;
using System.Text.Json.Serialization;

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
            if (response.IsSuccess)
            {
                var jsonData = JsonConvert.SerializeObject(response.Data, new JsonSerializerSettings
                {
                    ReferenceLoopHandling = ReferenceLoopHandling.Ignore,
                });
                return Ok(jsonData);
            }
            return BadRequest();
        }
        [HttpGet("{id}")]
        public async Task<IActionResult> GetPostById(int id)
        {
            var response = await _postService.GetPostByIdAsync(id);
            if (response.IsSuccess)
            {
                var jsonData = JsonConvert.SerializeObject(response.Data, new JsonSerializerSettings
                {
                    ReferenceLoopHandling = ReferenceLoopHandling.Ignore,
                });
                return Ok(jsonData);
            }
            return BadRequest();
        }
        [HttpGet("GetPostsByUserId/{id}")]
        public async Task<IActionResult> GetPostsByUserId(string id)
        {
            var response=await _postService.GetPostsByUserIdAsync(id);
            var jsonData = JsonConvert.SerializeObject(response.Data, new JsonSerializerSettings
            {
                ReferenceLoopHandling = ReferenceLoopHandling.Ignore,
            });
            return Ok(jsonData);
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
        [HttpPost("AddLikeToPost")]
        public async Task<IActionResult> AddLikeToPost(AddLikeDTO addLikeDTO)
        {
            var like = _mapper.Map<Like>(addLikeDTO);
             var response=  await _postService.AddLikeToPostAsync(like);
            IActionResult result = response.IsSuccess ? Ok() : NotFound();
            return result;
        }
    }
}
