using Marketify.Business.Abstract;
using Marketify.Business.DTOs.MessageDTOs;
using Marketify.Business.DTOs.Response;
using Marketify.DataAccess.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Marketify.Business.Concrete
{
    public class MessageManager : IMessageService
    {
        private readonly IMessageDal _messageDal;
        private readonly IChatDal _chatDal;

        public MessageManager(IMessageDal messageDal, IChatDal chatDal)
        {
            _messageDal = messageDal;
            _chatDal = chatDal;
        }

        public async Task<Response> CreateMessageAsync(CreateMessageDTO createMessageDTO)
        {
            var chat = await _chatDal.GetAsync(x => (x.UserId1 == createMessageDTO.SenderId && x.UserId2 == createMessageDTO.RecipientId)
            || (x.UserId1 == createMessageDTO.RecipientId && x.UserId2 == createMessageDTO.SenderId));

          
            if(chat != null )
            {

            await _messageDal.InsertAsync(new Entity.Message
            {
                MessageContent = createMessageDTO.MessageContent,
                ChatId = chat.ChatId ,
                SenderId = createMessageDTO.SenderId,
                RecipientId = createMessageDTO.RecipientId,
            });
            return Response.Success();
            }
            else
            {
                await _chatDal.InsertAsync(new Entity.Chat
                {
                    UserId1 = createMessageDTO.SenderId,
                    UserId2 = createMessageDTO.RecipientId,
                });
                var createdChat=await _chatDal.GetAsync(x=>x.UserId1==createMessageDTO.SenderId && x.UserId2==createMessageDTO.RecipientId);
                await _messageDal.InsertAsync(new Entity.Message
                {
                    MessageContent = createMessageDTO.MessageContent,
                    ChatId = createdChat.ChatId,
                    SenderId = createMessageDTO.SenderId,
                    RecipientId = createMessageDTO.RecipientId,
                });
                return Response.Success();
            }
            
        }
    }
}
