using AutoMapper;
using Marketify.Business.DTOs.UserDTOs;
using Marketify.Entity.Identity;

namespace Marketify.Api.Mapping
{
    public class Mapping:Profile
    {
        public Mapping()
        {
            CreateMap<User, LoginUserDTO>().ReverseMap();
            CreateMap<User, CreateUserDTO>();
        }
    }
}
