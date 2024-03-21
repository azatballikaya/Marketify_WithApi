using Marketify.UI.Models.Chat;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Security.Claims;

namespace Marketify.UI.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize]
    public class ChatController : Controller
    {
        private readonly IConfiguration _configuration;
        private readonly HttpClient client;
        private readonly string apiUrl;

        public ChatController(IHttpClientFactory httpClientFactory, IConfiguration configuration)
        {

            _configuration = configuration;
            apiUrl = _configuration.GetSection("ApiUrl").Get<string>();
            client = httpClientFactory.CreateClient();
        }
        public async Task<IActionResult> Index()
        {
            var userId=User.FindFirstValue(ClaimTypes.NameIdentifier);
            ViewBag.UserId=userId;
            var responseMessage=await client.GetAsync($"{apiUrl}Chat/GetChatByUserId/{userId}");
            if(responseMessage.IsSuccessStatusCode)
            {
                var jsonData=await responseMessage.Content.ReadAsStringAsync();
                var values = JsonConvert.DeserializeObject<List<ResultChatViewModel>>(jsonData);
                return View(values);
            }
            return View();
        }
    }
}
