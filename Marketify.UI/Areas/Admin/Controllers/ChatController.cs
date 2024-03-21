using Marketify.UI.Models.Chat;
using Marketify.UI.Models.Message;
using Marketify.UI.Models.User;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Newtonsoft.Json;
using System.Security.Claims;
using System.Text;

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
        [HttpGet]
        public async Task<IActionResult> SendMessage(string userId=null)
        {
            var responseMessage = await client.GetAsync(apiUrl + "User/GetAllUsers/true");
            if (responseMessage.IsSuccessStatusCode)
            {
                var jsonData= await responseMessage.Content.ReadAsStringAsync();
                var values=JsonConvert.DeserializeObject<List<ResultUserViewModel>>(jsonData);
                var myUser = values.FirstOrDefault(x => x.id == User.FindFirstValue(ClaimTypes.NameIdentifier));
                values.Remove(myUser);
                return View(values);
            }
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> SendMessage(CreateMessageViewModel createMessageViewModel)
        {
            createMessageViewModel.SenderId = User.FindFirstValue(ClaimTypes.NameIdentifier);
            var jsonData = JsonConvert.SerializeObject(createMessageViewModel);
            StringContent content = new StringContent(jsonData, Encoding.UTF8, "application/json");
            var responseMessage = await client.PostAsync(apiUrl + "Message", content);
            if (responseMessage.IsSuccessStatusCode)
            {
                return RedirectToAction("Index");

            }
            return View(createMessageViewModel);
        }
    }
}
