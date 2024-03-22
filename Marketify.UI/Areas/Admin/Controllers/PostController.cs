using Marketify.UI.Models.Comment;
using Marketify.UI.Models.Post;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Security.Claims;
using System.Text;

namespace Marketify.UI.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize]
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
        public async Task<IActionResult> Index()
        {
            HttpResponseMessage responseMessage;
            if (User.IsInRole("Admin"))
            {
                responseMessage = await client.GetAsync(apiUrl + "Post");
            }
            else
            {
                var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
                responseMessage = await client.GetAsync(apiUrl + $"Post/GetPostsByUserId/{userId}");
            }
            if (responseMessage.IsSuccessStatusCode)
            {
                var jsonData = await responseMessage.Content.ReadAsStringAsync();
                var values = JsonConvert.DeserializeObject<IEnumerable<ResultPostViewModel>>(jsonData);
               
                values=values.OrderByDescending(x => x.Offers.Count());
                return View(values);
            }
            return NotFound();
        }
        public async Task<IActionResult> GetPost(int id)
        {
            var responseMessage = await client.GetAsync(apiUrl + $"Post/{id}");
            if (responseMessage.IsSuccessStatusCode)
            {
                var jsonData = await responseMessage.Content.ReadAsStringAsync();
                var values = JsonConvert.DeserializeObject<ResultPostViewModel>(jsonData);
                return View(values);
            }
            return NotFound();
        }
        [HttpGet]
        public async Task<IActionResult> CreatePost()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> CreatePost(CreatePostViewModel createPostViewModel)
        {
            if (ModelState.IsValid)
            {
                var extension = Path.GetExtension(createPostViewModel.Image.FileName);
                var imageName = $"{Guid.NewGuid()}{extension}";
                var path = Path.Combine(Directory.GetCurrentDirectory(), $"wwwroot/img/{imageName}");
                using (var stream = new FileStream(path, FileMode.Create))
                {
                    await createPostViewModel.Image.CopyToAsync(stream);
                }
                createPostViewModel.UserId = User.FindFirstValue(ClaimTypes.NameIdentifier);
                createPostViewModel.ImageUrl = imageName;
                var jsonData = JsonConvert.SerializeObject(createPostViewModel);
                StringContent content = new StringContent(jsonData, Encoding.UTF8, "application/json");
                var responseMessage = await client.PostAsync(apiUrl + "Post", content);
                if (responseMessage.IsSuccessStatusCode)
                {
                    return RedirectToAction("Index");
                }


            }
            return View(createPostViewModel);
        }
        [HttpGet]
        public async Task<IActionResult> Delete(int id)
        {
            var responseMessage = await client.GetAsync(apiUrl + $"Post/{id}");
            if (responseMessage.IsSuccessStatusCode)
            {
                var jsonData = await responseMessage.Content.ReadAsStringAsync();
                var value = JsonConvert.DeserializeObject<ResultPostViewModel>(jsonData);
                return View(value);
            }
            return NotFound();

        }
        [HttpPost]
        public async Task<IActionResult> Delete(ResultPostViewModel resultPostViewModel)
        {
            var responseMessage = await client.DeleteAsync(apiUrl + $"Post/{resultPostViewModel.Id}");
            if (responseMessage.IsSuccessStatusCode)
            {

                return RedirectToAction("Index");
            }
            return RedirectToAction("Delete", new { id = resultPostViewModel.Id });
        }
    }
}