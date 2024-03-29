﻿using Marketify.UI.Models.User;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Runtime.ConstrainedExecution;
using System.Security.Claims;
using System.Text;

namespace Marketify.UI.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize(Roles ="Admin")]
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
        [AllowAnonymous]
        [Authorize]
        [HttpGet]
        public async Task<IActionResult> EditProfile()
        {
            var responseMessage = await client.GetAsync(apiUrl + $"User/{User.FindFirstValue(ClaimTypes.NameIdentifier)}");
            if(responseMessage.IsSuccessStatusCode)
            {
                var jsonData= await responseMessage.Content.ReadAsStringAsync();
                var value=JsonConvert.DeserializeObject<UpdateUserViewModel>(jsonData);
                return View(value);
            }
            return NotFound();
        }
        [AllowAnonymous]
        [Authorize]
        
        [HttpPost]
        public async Task<IActionResult> EditProfile(UpdateUserViewModel updateUserViewModel)
        {
            updateUserViewModel.IsApproved = true;
            var jsonData=JsonConvert.SerializeObject(updateUserViewModel);
            StringContent content = new StringContent(jsonData,Encoding.UTF8,"application/json");
            var responseMessage = await client.PutAsync(apiUrl + "User", content);
          
                return RedirectToAction("Index", "Post", new {area="Admin"});
           
        }
       
        public async Task<IActionResult> AddUserToAdminRole(string id)
        {
            AddUserToRoleViewModel addUserToRoleViewModel = new AddUserToRoleViewModel()
            {
                RoleName = "Admin",
                UserId = id
            };
            var jsonData=JsonConvert.SerializeObject(addUserToRoleViewModel);
            StringContent content=new StringContent(jsonData,Encoding.UTF8,"application/json");
            var responseMessage = await client.PostAsync(apiUrl + "Role/AddUserToRoleByName",content);
            return RedirectToAction("Index");
        }
        public async Task<IActionResult> IsntApproved()
        {
            var responseMessage = await client.GetAsync(apiUrl + "User/GetAllUsers/false");
            if (responseMessage.IsSuccessStatusCode)
            {

            var jsonData=await responseMessage.Content.ReadAsStringAsync();
            var value=JsonConvert.DeserializeObject<List<ResultUserViewModel>>(jsonData);
                return View(value);
            }
            return View();
        }
        public async Task<IActionResult> ApproveUser(string id)
        {
            var responseMessage = await client.GetAsync(apiUrl + "User/ApproveUser/" + $"{id}");
            if (responseMessage.IsSuccessStatusCode)
            {
                return RedirectToAction("IsntApproved");
            }
            return NotFound();
        }
     }
}
