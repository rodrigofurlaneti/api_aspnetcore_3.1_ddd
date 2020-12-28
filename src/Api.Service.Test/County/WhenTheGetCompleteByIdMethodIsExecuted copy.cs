using System;
using System.Threading.Tasks;
using Api.Domain.Dtos.County;
using Api.Domain.Interfaces.Services.County;
using Moq;
using Xunit;
namespace Api.Service.Test.County
{
    public class WhenTheGetCompleteByIdMethodIsExecuted : CountyTest
    {
        private ICountyService _serviceCounty;
        private Mock<ICountyService> _serviceMock;
        [Fact(DisplayName="É possivel executar o método GetCompleteById.")]
        public async Task WhenToRunTheGetCompleteByIdMethod()
        {
            _serviceMock = new Mock<ICountyService>();
            _serviceMock.Setup(m => m.GetCompleteByIbge(CodeIbgeCounty)).ReturnsAsync(countyCompleteDto);
            _serviceCounty = _serviceMock.Object;
            var result = await _serviceCounty.GetCompleteByIbge(CodeIbgeCounty);
            Assert.NotNull(result);
            Assert.True(result.Id == IdCounty);
            Assert.Equal(NameCounty, result.Name);
            Assert.Equal(CodeIbgeCounty, result.CodeIbge);
            Assert.NotNull(result.FederalUnit);
        }
    }
}