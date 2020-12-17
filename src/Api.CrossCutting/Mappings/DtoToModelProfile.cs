using Api.Domain.Dtos;
using Api.Domain.Dtos.County;
using Api.Domain.Dtos.FederalUnit;
using Api.Domain.Dtos.User;
using Api.Domain.Dtos.ZipCode;
using Api.Domain.Models;
using AutoMapper;
namespace Api.CrossCutting.Mappings
{
    public class DtoToModelProfile : Profile
    {
        public DtoToModelProfile()
        {
            #region County
            //County
                CreateMap<CountyModel, CountyDto>().ReverseMap();
                CreateMap<CountyModel, CountyCreateDto>().ReverseMap();
                CreateMap<CountyModel, CountyUpdateDto>().ReverseMap();
            #endregion
            #region Unit
            //FederalUnit
                CreateMap<FederalUnitModel, FederalUnitDto>().ReverseMap();
            #endregion 
            #region User
            //User
                CreateMap<UserModel, UserDto>().ReverseMap();
                CreateMap<UserModel, UserCreateDto>().ReverseMap();
                CreateMap<UserModel, UserUpdateDto>().ReverseMap();
            #endregion
            #region ZipCode
            //ZipCode
                CreateMap<ZipCodeModel, ZipCodeDto>().ReverseMap();
                CreateMap<ZipCodeModel, ZipCodeCreateDto>().ReverseMap();
                CreateMap<ZipCodeModel, ZipCodeUpdateDto>().ReverseMap();
            #endregion
        }       
    }
}