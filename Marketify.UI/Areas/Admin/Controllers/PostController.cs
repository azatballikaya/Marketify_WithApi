using Marketify.UI.Models.Comment;
using Marketify.UI.Models.Post;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace Marketify.UI.Areas.Admin.Controllers
{
    [Area("Admin")]
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
            var responseMessage = await client.GetAsync(apiUrl + "Post");
            if (responseMessage.IsSuccessStatusCode)
            {
                var jsonData = await responseMessage.Content.ReadAsStringAsync();
                var values = JsonConvert.DeserializeObject<List<ResultPostViewModel>>(jsonData);
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
        public async Task<IActionResult> Delete(int id)
        {
            var responseMessage = await client.DeleteAsync(apiUrl + $"Post/{id}");
            return RedirectToAction("Index");
        }
    }
}
