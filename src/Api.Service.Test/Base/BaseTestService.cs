using AutoMapper;
namespace Api.Service.Test.Base
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