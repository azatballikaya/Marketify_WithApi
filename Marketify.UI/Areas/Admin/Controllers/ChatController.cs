﻿using Marketify.UI.Models.Chat;
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
        public async Task<IActionResult> GetChat(int id)
        {
            var responseMessage = await client.GetAsync(apiUrl + $"Chat/{id}");
            if (responseMessage.IsSuccessStatusCode)
            {
                var jsonData = await responseMessage.Content.ReadAsStringAsync();
                var values = JsonConvert.DeserializeObject<ResultChatViewModel>(jsonData);
              
                return View(values);
            }
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> GetChat(CreateMessageViewModel createMessageViewModel,int chatId)
        {
            createMessageViewModel.SenderId = User.FindFirstValue(ClaimTypes.NameIdentifier);
            var jsonData = JsonConvert.SerializeObject(createMessageViewModel);
            StringContent content = new StringContent(jsonData, Encoding.UTF8, "application/json");
            var responseMessage = await client.PostAsync(apiUrl + "Message", content);
            if (responseMessage.IsSuccessStatusCode)
            {
                return RedirectToAction("GetChat", new {id=$"{chatId}"});

            }
            return NotFound();
        }
        [HttpGet]
        public async Task<IActionResult> SendMessage(string id=null)
        {
            HttpResponseMessage responseMessage;
            string jsonData;
            var myUserId = User.FindFirstValue(ClaimTypes.NameIdentifier);

            if (id!=null)
            {
                responseMessage = await client.GetAsync(apiUrl + $"Chat/GetChatByUserId/{myUserId}");
                if (responseMessage.IsSuccessStatusCode)
                {
                    jsonData=await responseMessage.Content.ReadAsStringAsync();
                    var values=JsonConvert.DeserializeObject<List<ResultChatViewModel>>(jsonData);
                    var chat= values.FirstOrDefault(x => x.UserId1 == id || x.UserId2 == id);
                   if (chat!=null )
                    {
                        return RedirectToAction("GetChat", new {id=chat.ChatId});
                    }
                    
                }
            }

            ViewBag.UserId = id;
             responseMessage = await client.GetAsync(apiUrl + "User/GetAllUsers/true");
            if (responseMessage.IsSuccessStatusCode)
            {
                jsonData= await responseMessage.Content.ReadAsStringAsync();
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
            return View();
        }
    }
}
