using Marketify.UI.Models.Login;
using Marketify.UI.Models.User;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Security.Claims;
using System.Text;

namespace Marketify.UI.Controllers
{
    public class LoginController : Controller
    {
        private readonly IConfiguration _configuration;
        private readonly HttpClient client;
        private readonly string apiUrl;

        public LoginController(IHttpClientFactory httpClientFactory, IConfiguration configuration)
        {

            _configuration = configuration;
            apiUrl = _configuration.GetSection("ApiUrl").Get<string>();
            client = httpClientFactory.CreateClient();
        }
        [HttpGet]
        public IActionResult Login()
        {
            if (User.Identity.IsAuthenticated)
            {
                return Redirect("~/");
            }
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Login(LoginViewModel loginViewModel) {
            StringContent content=new StringContent(JsonConvert.SerializeObject(loginViewModel),Encoding.UTF8,"application/json");
            var responseMessage = await client.PostAsync(apiUrl + "User/Login",content);
            if (responseMessage.IsSuccessStatusCode) { 
                var jsonData=await responseMessage.Content.ReadAsStringAsync();
                var user=JsonConvert.DeserializeObject<LoginUserViewModel>(jsonData);
                List<Claim> claims = new List<Claim>()
                {
                    new Claim(ClaimTypes.NameIdentifier, user.User.id),
                    new Claim(ClaimTypes.Name, user.User.userName),
                    new Claim(ClaimTypes.Role,user.RoleName[0])

                };
                var userIdentity=new ClaimsIdentity(claims,"Login");
                ClaimsPrincipal principal=new ClaimsPrincipal(userIdentity);
                await HttpContext.SignInAsync(principal);
                
            }
            return Redirect("~/");
        }
    }
}
