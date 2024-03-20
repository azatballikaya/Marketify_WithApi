using Marketify.UI.Models.Like;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Security.Claims;
using System.Text;

namespace Marketify.UI.Controllers
{
    public class PostController : Controller
    {
        private readonly IConfiguration _configuration;
        private readonly HttpClient client;
        private readonly string apiUrl;

        public PostController(IHttpClientFactory httpClientFactory, IConfiguration configuration)
        {

            _configuration = configuration;
            apiUrl = _configuration.GetSection("ApiUrl").Get<string>();
            client = httpClientFactory.CreateClient();
        }
        public async Task<JsonResult> AddLikeToPost(int id)
        {

            AddLikeToPostViewModel addLikeToPost = new AddLikeToPostViewModel { PostId = id, UserId = User.FindFirstValue(ClaimTypes.NameIdentifier) };
            StringContent content = new StringContent(JsonConvert.SerializeObject(addLikeToPost), Encoding.UTF8, "application/json");
            var responseMessage=await client.PostAsync(apiUrl+"Post/AddLikeToPost",content);
            var jsonData=await responseMessage.Content.ReadAsStringAsync();

            return Json(jsonData);
        }
        public async Task<JsonResult> IsLiked(int id)
        {
            AddLikeToPostViewModel addLikeToPostViewModel = new AddLikeToPostViewModel
            {
                PostId = id,
                UserId = User.FindFirstValue(ClaimTypes.NameIdentifier)
            };
            StringContent content = new StringContent(JsonConvert.SerializeObject(addLikeToPostViewModel), Encoding.UTF8, "application/json");
            var responseMessage = await client.PostAsync(apiUrl + "Post/IsLiked", content);
            var jsonData = await responseMessage.Content.ReadAsStringAsync();

            return Json(jsonData);

        }
    }
}
