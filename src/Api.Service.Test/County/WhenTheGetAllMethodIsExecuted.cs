using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Api.Domain.Dtos.County;
using Api.Domain.Interfaces.Services.County;
using Moq;
using Xunit;
namespace Api.Service.Test.County
{
    public class WhenTheGetAllMethodIsExecuted : CountyTest
    {
        private ICountyService _serviceCounty;
        private Mock<ICountyService> _serviceMock;
        [Fact(DisplayName="É possivel executar o método GetAll.")]
        public async Task WhenToRunTheGetAllMethod()
        {
            _serviceMock = new Mock<ICountyService>();
            _serviceMock.Setup(m => m.GetAll()).ReturnsAsync(listCountyDto);
            _serviceCounty = _serviceMock.Object;
            var result = await _serviceCounty.GetAll();
            Assert.NotNull(result);
            Assert.True(result.Count() == 10);
            var _listResult = new List<CountyDto>();
            _serviceMock = new Mock<ICountyService>();
            _serviceMock.Setup(m => m.GetAll()).ReturnsAsync(_listResult.AsEnumerable);
            _serviceCounty = _serviceMock.Object;
        }
    }
}