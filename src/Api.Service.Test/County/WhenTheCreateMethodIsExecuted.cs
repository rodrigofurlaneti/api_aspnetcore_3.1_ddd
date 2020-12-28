using System;
using System.Threading.Tasks;
using Api.Domain.Dtos.County;
using Api.Domain.Interfaces.Services.County;
using Moq;
using Xunit;
namespace Api.Service.Test.County
{
    public class WhenTheCreateMethodIsExecuted : CountyTest
    {
        private ICountyService _serviceCounty;
        private Mock<ICountyService> _serviceMock;
        [Fact(DisplayName="É possivel executar o método Create.")]
        public async Task WhenToRunTheCreateMethod()
        {
            _serviceMock = new Mock<ICountyService>();
            _serviceMock.Setup(m => m.Post(countyCreateDto)).ReturnsAsync(countyCreateResultDto);
            _serviceCounty = _serviceMock.Object;
            var result = await _serviceCounty.Post(countyCreateDto);
            Assert.NotNull(result);
            Assert.Equal(NameCounty, result.Name);
            Assert.Equal(CodeIbgeCounty, result.CodeIbge);
            Assert.Equal(FederalUnitId, result.FederalUnitId);
        }
    }
}