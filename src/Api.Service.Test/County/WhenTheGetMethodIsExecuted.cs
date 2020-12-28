using System;
using System.Threading.Tasks;
using Api.Domain.Dtos.County;
using Api.Domain.Interfaces.Services.County;
using Moq;
using Xunit;
namespace Api.Service.Test.County
{
    public class WhenTheGetMethodIsExecuted : CountyTest
    {
        private ICountyService _serviceCounty;
        private Mock<ICountyService> _serviceMock;
        [Fact(DisplayName="É possivel executar o método Get.")]
        public async Task WhenToRunTheGetMethod()
        {
            _serviceMock = new Mock<ICountyService>();
            _serviceMock.Setup(m => m.Get(IdCounty)).ReturnsAsync(countyDto);
            _serviceCounty = _serviceMock.Object;
            var result = await _serviceCounty.Get(IdCounty);
            Assert.NotNull(result);
            Assert.True(result.Id == IdCounty);
            Assert.Equal(NameCounty, result.Name);
            Assert.Equal(CodeIbgeCounty, result.CodeIbge);
            _serviceMock = new Mock<ICountyService>();
            _serviceMock.Setup(m => m.Get(It.IsAny<Guid>())).Returns(Task.FromResult((CountyDto)null));
            _serviceCounty = _serviceMock.Object;
            result = await _serviceCounty.Get(IdCounty);
            Assert.Null(result);
        }
    }
}