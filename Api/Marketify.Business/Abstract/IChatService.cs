using Marketify.Business.DTOs.Response;
using Marketify.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Marketify.Business.Abstract
{
    public interface IChatService
    {
        Task<Response> CreateChatAsync(string userId1,string userId2);
        Task<Response> DeleteChatAsync(int chatId);
        Task<Response<List<Chat>>> GetUserChatsAsync(string userId);
       Task<Response<Chat>> GetChatAsync(int id);
    }
}
