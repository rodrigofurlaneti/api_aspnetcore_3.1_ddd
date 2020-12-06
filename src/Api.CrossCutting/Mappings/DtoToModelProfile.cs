using Api.Domain.Dtos;
using Api.Domain.Dtos.User;
using Api.Domain.Models;
using AutoMapper;
namespace Api.CrossCutting.Mappings
{
    public class DtoToModelProfile : Profile
    {
        public DtoToModelProfile()
        {
            CreateMap<UserModel, UserDto>().ReverseMap();
            CreateMap<UserModel, UserCreateDto>().ReverseMap();
            CreateMap<UserModel, UserUpdateDto>().ReverseMap();
        }       
    }
}