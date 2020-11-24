using System;
using AutoMapper;
using Api.CrossCutting.Mappings;
namespace Api.Service.Test.Base
{
    public class AutoMapperFixture : BaseTestService, IDisposable
    {
        public IMapper GetMapper()
        {
            MapperConfiguration configuration = new MapperConfiguration(config =>
           {
               config.AddProfile(new ModelToEntityProfile());
               config.AddProfile(new DtoToModelProfile());
               config.AddProfile(new EntityToDtoProfile());
           });
            return configuration.CreateMapper();
        }
        public void Dispose() { }
    }
}