
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
    public class PostManager : IPostService
    {
        private readonly IPostDal _postDal;
        private readonly ILikeDal _likeDal;

        public PostManager(IPostDal postDal, ILikeDal likeDal)
        {
            _postDal = postDal;
            _likeDal = likeDal;
        }

        public async Task<Response> AddLikeToPostAsync(Like like)
        {
          await _likeDal.InsertAsync(like);
            return Response.Success();
        }

        public async Task<Response> CreatePostAsync(Post post)
        {
         await _postDal.InsertAsync(post);
            return Response.Success();
        }

        public async Task<Response> DeletePostAsync(int id)
        {
            var post =await _postDal.GetAsync(x => x.Id == id);
            if(post != null) { 
            _postDal.DeleteAsync(post);
                return Response.Success();
            }
            return Response.Fail();
        }

        public async Task<Response<List<Post>>> GetAllPostsAsync()
        {
            var posts=await _postDal.GetAllAsync(include:x=>x.Include(y=>y.User).Include(z=>z.Comments));
            if (posts != null)
            {
                return Response<List<Post>>.Success(posts);
            }
            return Response<List<Post>>.Fail();
        }

        public async Task<Response<Post>> GetPostByIdAsync(int id)
        {
            var post=await _postDal.GetAsync(x=>x.Id == id,x=>x.Include(y=>y.User).Include(z=>z.Comments));
            if(post != null)
            {
                return Response<Post>.Success(post);
            }
            return Response<Post>.Fail();
        }

        public async Task<Response<List<Post>>> GetPostsByUserIdAsync(string userId)
        {
           var posts=await _postDal.GetAllAsync(x=>x.UserId == userId, x => x.Include(y => y.User).Include(z => z.Comments));
            if(posts != null)
            {
                return Response<List<Post>>.Success(posts);
            }
            return Response<List<Post>>.Fail(); 
        }

        public async Task<Response> UpdatePostAsync(Post post)
        {
            await _postDal.UpdateAsync(post);
            return Response.Success();
        }

        
    }
}
