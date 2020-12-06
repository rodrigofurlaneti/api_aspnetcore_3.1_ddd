using System;
using Api.CrossCutting.Mappings;
using AutoMapper;
namespace Api.Service.Test.Base
{
    public abstract class BaseTestService
    {
        public IMapper Mapper { get; set; }
        public BaseTestService()
        {
            Mapper = new AutoMapperFixture().GetMapper();
        }
    
        public class AutoMapperFixture : IDisposable
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
}