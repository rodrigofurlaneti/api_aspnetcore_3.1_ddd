using System;
using System.Threading.Tasks;
using Api.Domain.Interfaces.Services.County;
using Moq;
using Xunit;
namespace Api.Service.Test.County
{
    public class WhenTheDeleteMethodIsExecuted : CountyTest
    {
        private ICountyService _serviceCounty;
        private Mock<ICountyService> _serviceMock;
        [Fact(DisplayName="É possivel executar o método Delete.")]
        public async Task WhenToRunTheDeleteMethod()
        {
            _serviceMock = new Mock<ICountyService>();
            _serviceMock.Setup(m => m.Delete(IdCounty)).ReturnsAsync(true);
            _serviceCounty = _serviceMock.Object;
            var result = await _serviceCounty.Delete(IdCounty);
            Assert.True(result);
            _serviceMock = new Mock<ICountyService>();
            _serviceMock.Setup(m => m.Delete(It.IsAny<Guid>())).ReturnsAsync(false);
            _serviceCounty = _serviceMock.Object;
            result = await _serviceCounty.Delete(Guid.NewGuid());
            Assert.False(result);
        }
    }
}