using Marketify.Business.DTOs.MessageDTOs;
using Marketify.Business.DTOs.Response;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Marketify.Business.Abstract
{
    public interface IMessageService
    {
        Task<Response> CreateMessageAsync(CreateMessageDTO createMessageDTO);
        
    }
}
