using System;
using Xunit;
using AutoMapper;
using Api.CrossCutting.Mappings;
namespace Api.Service.Test
{
    public abstract class BaseTestService
    {
        public IMapper Mapper { get; set; }
        public BaseTestService()
        {
            IMapper Mapper = new AutoMapperFixture().GetMapper();
        }
    }
}