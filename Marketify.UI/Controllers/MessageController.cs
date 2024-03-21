using Microsoft.AspNetCore.Mvc;

namespace Marketify.UI.Controllers
{
    public class MessageController : Controller
    {
        private readonly IConfiguration _configuration;
        private readonly HttpClient client;
        private readonly string apiUrl;

        public MessageController(IHttpClientFactory httpClientFactory, IConfiguration configuration)
        {

            _configuration = configuration;
            apiUrl = _configuration.GetSection("ApiUrl").Get<string>();
            client = httpClientFactory.CreateClient();
        }
        public IActionResult SendMessage()
        {
            return View();
        }
    }
}
