using System;
using System.Threading.Tasks;
using Api.Domain.Dtos.FederalUnit;
using Api.Domain.Interfaces.Services.FederalUnit;
using Moq;
using Xunit;
namespace Api.Service.Test.FederalUnit
{
    public class ToRunningGet : FederalUnitTest
    {
        private IFederalUnitService _serviceFederalUnit;
        private Mock<IFederalUnitService> _serviceMock;
        [Fact(DisplayName="É possivel executar o método Get.")]
        public async Task WhenToRunTheGetMethod()
        {
            _serviceMock = new Mock<IFederalUnitService>();
            _serviceMock.Setup(m => m.Get(Id)).ReturnsAsync(federalUnitDto);
            _serviceFederalUnit = _serviceMock.Object;
            var result = await _serviceFederalUnit.Get(Id);
            Assert.NotNull(result);
            Assert.True(result.Id == Id);
            Assert.Equal(Name, result.Name);
            _serviceMock = new Mock<IFederalUnitService>();
            _serviceMock.Setup(m => m.Get(It.IsAny<Guid>())).Returns(Task.FromResult((FederalUnitDto)null));
            _serviceFederalUnit = _serviceMock.Object;
            var _record = await _serviceFederalUnit.Get(Id);
            Assert.Null(_record);
        }
    }
}