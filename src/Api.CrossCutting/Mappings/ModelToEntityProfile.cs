using Api.Domain.Entities;
using Api.Domain.Models;
using AutoMapper;
namespace Api.CrossCutting.Mappings
{
    public class ModelToEntityProfile : Profile
    {
        public ModelToEntityProfile()
        {
            #region County
            //County
                CreateMap<CountyEntity, CountyModel>().ReverseMap();
            #endregion
            #region FederalUnit
            //FederalUnit
                CreateMap<FederalUnitEntity, FederalUnitModel>().ReverseMap();
            #endregion
            #region User
            //User
                CreateMap<UserEntity, UserModel>().ReverseMap();
            #endregion
            #region ZipCode
            //ZipCode
                CreateMap<ZipCodeEntity, ZipCodeModel>().ReverseMap();
            #endregion
        }        
    }
}