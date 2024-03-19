using Marketify.UI.Models.User;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace Marketify.UI.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class UserController : Controller
    {
       
        private readonly IConfiguration _configuration;
        private readonly HttpClient client;
        private readonly string apiUrl;

        public UserController(IHttpClientFactory httpClientFactory, IConfiguration configuration)
        {
          
            _configuration = configuration;
            apiUrl = _configuration.GetSection("ApiUrl").Get<string>();
            client = httpClientFactory.CreateClient();
        }

        public async Task<IActionResult> Index()
        {
            var responseMessage = await client.GetAsync(apiUrl + "User/WithoutAdmin");
            if(responseMessage.IsSuccessStatusCode)
            {
                var jsonData=await responseMessage.Content.ReadAsStringAsync();
                var value=JsonConvert.DeserializeObject<List<ResultUserViewModel>>(jsonData);
                return View(value);
            }
            return View();
        }
        public async Task<IActionResult> Delete(string id)
        {
            var responseMessage =await client.DeleteAsync(apiUrl + "User/" + $"{id}");
           
                return RedirectToAction("Index");
            

        }
            }
}
