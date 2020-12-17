using Api.Domain.Dtos;
using Api.Domain.Dtos.County;
using Api.Domain.Dtos.FederalUnit;
using Api.Domain.Dtos.User;
using Api.Domain.Dtos.ZipCode;
using Api.Domain.Entities;
using AutoMapper;
namespace Api.CrossCutting.Mappings
{
    public class EntityToDtoProfile : Profile
    {
        public EntityToDtoProfile()
        {
            #region County
            //County
                CreateMap<CountyDto, CountyEntity>().ReverseMap();
                CreateMap<CountyCompleteDto, CountyEntity>().ReverseMap();
                CreateMap<CountyCreateResultDto, CountyEntity>().ReverseMap();
                CreateMap<CountyUpdateResultDto, CountyEntity>().ReverseMap();
            #endregion
            #region FederalUnit
            //FederalUnit
                CreateMap<FederalUnitDto, FederalUnitEntity>().ReverseMap();
            #endregion
            #region User
            //User
                CreateMap<UserDto, UserEntity>().ReverseMap();
                CreateMap<UserCreateResultDto, UserEntity>().ReverseMap();
                CreateMap<UserUpdateResultDto, UserEntity>().ReverseMap();
            #endregion
            #region ZipCode
            //ZipCode
                CreateMap<ZipCodeDto, ZipCodeEntity>().ReverseMap();
                CreateMap<ZipCodeCreateResultDto, ZipCodeEntity>().ReverseMap();
                CreateMap<ZipCodeUpdateResultDto, ZipCodeEntity>().ReverseMap();
            #endregion
        }
    }
}