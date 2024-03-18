using Marketify.Business.DTOs.Response;
using Marketify.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Marketify.Business.Abstract
{
    public interface ICommentService
    {
        Task<Response> CreateCommentAsync(Comment comment);
        Task<Response> DeleteCommentAsync(int id);
    }
}
