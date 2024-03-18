
using Marketify.Business.Abstract;
using Marketify.Business.DTOs.Response;
using Marketify.DataAccess.Abstract;
using Marketify.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Marketify.Business.Concrete
{
    public class CommentManager : ICommentService
    {
        private readonly ICommentDal _commentDal;

        public CommentManager(ICommentDal commentDal)
        {
            _commentDal = commentDal;
        }

        public async Task<Response> CreateCommentAsync(Comment comment)
        {
            await _commentDal.InsertAsync(comment);
            return Response.Success();
        }

        public async Task<Response> DeleteCommentAsync(int id)
        {
            var comment=await _commentDal.GetAsync(x=> x.Id == id);
            if (comment != null)
            {
            await _commentDal.DeleteAsync(comment);
                return Response.Success();
            }
            return Response.Fail();
            

        }
    }
}
