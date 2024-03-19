using Marketify.Business.DTOs.Response;
using Marketify.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Marketify.Business.Abstract
{
    public interface IPostService
    {
        Task<Response<Post>> GetPostByIdAsync(int id);
        Task<Response<List<Post>>> GetPostsByUserIdAsync(string userId);
        Task<Response<List<Post>>> GetAllPostsAsync();
        Task<Response> CreatePostAsync(Post post);
        Task<Response> UpdatePostAsync(Post post);
        Task<Response> DeletePostAsync(int id);   
        Task<Response> AddLikeToPostAsync(Like like)
    }
}
