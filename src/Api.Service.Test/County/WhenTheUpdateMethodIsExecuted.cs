using System.Threading.Tasks;
using Api.Domain.Interfaces.Services.County;
using Moq;
using Xunit;
namespace Api.Service.Test.County
{
    public class WhenTheUpdateMethodIsExecuted : CountyTest
    {
        private ICountyService _serviceCounty;
        private Mock<ICountyService> _serviceMock;
        [Fact(DisplayName="É possivel executar o método Update.")]
        public async Task WhenToRunTheUpdateMethod()
        {
            _serviceMock = new Mock<ICountyService>();
            _serviceMock.Setup(m => m.Put(countyUpdateDto)).ReturnsAsync(countyUpdateResultDto);
            _serviceCounty = _serviceMock.Object;
            var resultUpdate = await _serviceCounty.Put(countyUpdateDto);
            Assert.NotNull(resultUpdate);
            Assert.Equal(NameUpdate, resultUpdate.Name);
            Assert.Equal(CodeIbgeUpdate, resultUpdate.CodeIbge);
            Assert.Equal(FederalUnitId, resultUpdate.FederalUnitId);
        }
    }
}