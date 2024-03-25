
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
            var post=await _postDal.GetAsync(x=>x.Id==like.PostId,include:x=>x.Include(y=>y.Likes));
            var isLiked= post.Likes.FirstOrDefault(x=>x.UserId==like.UserId && x.PostId==like.PostId);
            
            if(isLiked!=null)
            {
                await _likeDal.DeleteAsync(isLiked);
                return Response.Success();
            }
          await _likeDal.InsertAsync(like);

            return Response.Success();
        }

        public async Task<Response> CreatePostAsync(Post post)
        {
            post.ClickCount = 0;
         await _postDal.InsertAsync(post);
            return Response.Success();
        }

        public async Task<Response> DeletePostAsync(int id)
        {
            var post =await _postDal.GetAsync(x => x.Id == id);
            if(post != null) { 
              await  _postDal.DeleteAsync(post);
                return Response.Success();
            }
            return Response.Fail();
        }

        public async Task<Response<List<Post>>> GetAllPostsAsync()
        {
            var posts=await _postDal.GetAllAsync(include:x=>x.Include(y=>y.User).Include(z=>z.Comments).ThenInclude(a=>a.User).Include(k=>k.Likes).Include(a=>a.Offers));
            if (posts != null)
            {
                return Response<List<Post>>.Success(posts);
            }
            return Response<List<Post>>.Fail();
        }

        public async Task<Response<Post>> GetPostByIdAsync(int id)
        {
            var post=await _postDal.GetAsync(x=>x.Id == id,x=>x.Include(y=>y.User).Include(z=>z.Comments).ThenInclude(a=>a.User).Include(k=>k.Likes).Include(a=>a.Offers));
            if(post != null)
            {
                return Response<Post>.Success(post);
            }
            return Response<Post>.Fail();
        }

        public async Task<Response<List<Post>>> GetPostsByUserIdAsync(string userId)
        {
           var posts=await _postDal.GetAllAsync(x=>x.UserId.Equals(userId),x=>x.Include(y=>y.Comments).Include(z=>z.Likes).Include(k=>k.User).Include(a=>a.Offers));
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
        public async Task<Response> IncrementClickCountAsync(int postId)
        {
            var post = await _postDal.GetAsync(x => x.Id == postId);
            if(post != null)
            {
                post.ClickCount++;
                await _postDal.UpdateAsync(post);
                return Response.Success();
            }
            return Response.Fail();
        }
        
    }
}
