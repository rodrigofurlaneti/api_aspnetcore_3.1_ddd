using System;
using Xunit;
using AutoMapper;
using Api.CrossCutting.Mappings;
namespace Api.Service.Test
{
    public class AutoMapperFixture : BaseTestService, IDisposable
    {
        public IMapper GetMapper()
        {
            var configuration = new MapperConfiguration(config =>
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