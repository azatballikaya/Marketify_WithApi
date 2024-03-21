using Marketify.Business.Abstract;
using Marketify.Business.DTOs.Response;
using Marketify.DataAccess.Abstract;
using Marketify.Entity;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Marketify.Business.Concrete
{
    public class ChatManager : IChatService
    {
        private readonly IChatDal _chatDal;

        public ChatManager(IChatDal chatDal)
        {
            _chatDal = chatDal;
        }
        public async Task<Response<List<Chat>>> GetUserChatsAsync(string userId)
        {
          var chats=  await _chatDal.GetAllAsync(x=>x.UserId1 == userId || x.UserId2==userId, x=>x.Include(y=>y.Messages));
            if (chats != null)
            {
                return Response<List<Chat>>.Success(chats);
            }
            return Response<List<Chat>>.Fail();
        }
        public async Task<Response> CreateChatAsync(string userId1, string userId2)
        {
            await _chatDal.InsertAsync(new Entity.Chat
            {
                UserId1 = userId1,
                UserId2 = userId2
            });
            return Response.Success();
        }

        public async Task<Response> DeleteChatAsync(int chatId)
        {
            var chat = await _chatDal.GetAsync(x=>x.ChatId==chatId);
            await _chatDal.DeleteAsync(chat);
            return Response.Success();
        }
    }
}
