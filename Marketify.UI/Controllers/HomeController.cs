using Marketify.UI.Models;
using Marketify.UI.Models.Post;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Diagnostics;
using System.Security.Claims;

namespace Marketify.UI.Controllers
{
    public class HomeController : Controller
    {
        private readonly IConfiguration _configuration;
        private readonly HttpClient client;
        private readonly string apiUrl;

        public HomeController(IHttpClientFactory httpClientFactory, IConfiguration configuration)
        {

            _configuration = configuration;
            apiUrl = _configuration.GetSection("ApiUrl").Get<string>();
            client = httpClientFactory.CreateClient();
        }
        public async Task<IActionResult> Index()
        {

            var responseMessage=await client.GetAsync(apiUrl+"Post");
            if(responseMessage.IsSuccessStatusCode)
            {
                var jsonData=await responseMessage.Content.ReadAsStringAsync();
                var values=JsonConvert.DeserializeObject<IEnumerable<ResultPostViewModel>>(jsonData);
                values=values.OrderByDescending(x=>x.Offers.Count);
                return View(values);
            }
            return View();
        }
        public async Task<IActionResult> GetPost(int id)
        {
            var responseMessage = await client.GetAsync(apiUrl + $"Post/{id}");
            if (responseMessage.IsSuccessStatusCode)
            {
                var jsonData=await responseMessage.Content.ReadAsStringAsync();
                var value=JsonConvert.DeserializeObject<ResultPostViewModel>(jsonData);
               
                
                responseMessage = User.FindFirstValue(ClaimTypes.NameIdentifier).ToLower() != value.UserId.ToLower() ?  await client.GetAsync(apiUrl + $"Post/IncrementClickCount/{id}") : responseMessage;
               
                if (responseMessage.IsSuccessStatusCode)
                {

                return View(value);
                }
                
            }
            return NotFound();
        }
        public async Task<IActionResult> GetUser(string id)
        {
            var responseMessage = await client.GetAsync(apiUrl + $"Post/GetPostsByUserId/{id}");
            if (responseMessage.IsSuccessStatusCode)
            {
                var jsonData = await responseMessage.Content.ReadAsStringAsync();
                var values = JsonConvert.DeserializeObject<List<ResultPostViewModel>>(jsonData);
                values=values.OrderByDescending(x=>x.Offers.Count).ToList();
                return View(values);
            }
            return NotFound();
        }


    }
}
