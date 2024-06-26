﻿using AutoMapper;
using Marketify.Business.DTOs;
using Marketify.Business.DTOs.ChatDTOs;
using Marketify.Business.DTOs.CommentDTOs;
using Marketify.Business.DTOs.LikeDTOs;
using Marketify.Business.DTOs.PostDTOs;
using Marketify.Business.DTOs.UserDTOs;
using Marketify.Entity;
using Marketify.Entity.Identity;

namespace Marketify.Api.Mapping
{
    public class Mapping:Profile
    {
        public Mapping()
        {
            CreateMap<User, LoginUserDTO>().ReverseMap();
            CreateMap<User, CreateUserDTO>().ReverseMap();

            CreateMap<Post,CreatePostDTO>().ReverseMap();
            CreateMap<Post,UpdatePostDTO>().ReverseMap();

            CreateMap<Comment,CreateCommentDTO>().ReverseMap();

            CreateMap<Like,AddLikeDTO>().ReverseMap();  
            
            CreateMap<Offer,CreateOfferDTO>().ReverseMap();   
            
            CreateMap<Chat,ResultChatDTO>().ReverseMap();
        }
    }
}
