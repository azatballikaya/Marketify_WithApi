using Marketify.UI.Models.Offer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Security.Claims;

namespace Marketify.UI.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize]
    public class OfferController : Controller
    {
        private readonly IConfiguration _configuration;
        private readonly HttpClient client;
        private readonly string apiUrl;

        public OfferController(IHttpClientFactory httpClientFactory, IConfiguration configuration)
        {

            _configuration = configuration;
            apiUrl = _configuration.GetSection("ApiUrl").Get<string>();
            client = httpClientFactory.CreateClient();
        }
        public async Task<IActionResult> GetOffer(int id)
        {
            var responseMessage = await client.GetAsync(apiUrl + $"Offer/{id}");
            if (responseMessage.IsSuccessStatusCode)
            {

                var jsonData = await responseMessage.Content.ReadAsStringAsync();
                var values = JsonConvert.DeserializeObject<ResultOfferViewModel>(jsonData);
                return View(values);
            }
            return NotFound();
        }
        public async Task<IActionResult> IncomingOffers()
        {
            var userId=User.FindFirstValue(ClaimTypes.NameIdentifier);
            var responseMessage = await client.GetAsync(apiUrl + $"Offer/GetIncomingOffers/{userId}");
            if (responseMessage.IsSuccessStatusCode)
            {

            var jsonData=await responseMessage.Content.ReadAsStringAsync();
            var values=JsonConvert.DeserializeObject<List<ResultOfferViewModel>>(jsonData);
                return View(values);
            }

            return View();
        }
        public async Task<IActionResult> MadeOffers()
        {
            var userId=User.FindFirstValue(ClaimTypes.NameIdentifier);
            var responseMessage = await client.GetAsync(apiUrl + $"offer/GetMadeOffers/{userId}");
            if (responseMessage.IsSuccessStatusCode)
            {

                var jsonData = await responseMessage.Content.ReadAsStringAsync();
                var values = JsonConvert.DeserializeObject<List<ResultOfferViewModel>>(jsonData);
                return View(values);
            }

            return View();

        }
    }
}
