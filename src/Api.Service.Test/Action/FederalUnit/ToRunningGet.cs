using System;
using System.Threading.Tasks;
using Api.Domain.Dtos.FederalUnit;
using Api.Domain.Interfaces.Services.FederalUnit;
using Moq;
using Xunit;
namespace Api.Service.Test.Action.FederalUnit
{
    public class ToRunningGet : Api.Service.Test.Model.FederalUnitTest
    {
        public IFederalUnitService _serviceFederalUnit;
        public Mock<IFederalUnitService> _serviceMook;
        [Fact(DisplayName="É possivel executar o método Get.")]
        public async Task WhenToRunTheGetMethod()
        {
            _serviceMook = new Mock<IFederalUnitService>();
            _serviceMook.Setup(m => m.Get(Id)).ReturnsAsync(federalUnitDto);
            _serviceFederalUnit = _serviceMook.Object;
            var result = await _serviceFederalUnit.Get(Id);
            Assert.NotNull(result);
            Assert.True(result.Id == Id);
            Assert.Equal(Name, result.Name);
            _serviceMook = new Mock<IFederalUnitService>();
            //_serviceMock.Setup(m => m.Get(It.IsAny<Guid>())).ReturnsAsync(Task.FromResult((FederalUnitDto)null));
            //_serviceFederalUnit = _serviceMock.Object;
            var _record = await _serviceFederalUnit.Get(Id);
            Assert.Null(_record);
        }
    }
}