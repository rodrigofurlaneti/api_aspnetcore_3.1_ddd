using System.Threading.Tasks;
using Api.Domain.Dtos.FederalUnit;
using Api.Domain.Interfaces.Services.FederalUnit;
using Moq;
using Xunit;
using System.Linq;
using System.Collections.Generic;
namespace Api.Service.Test.Action.FederalUnit
{
    public class ToRunningGetAll : Api.Service.Test.Model.FederalUnitTest
    {
        private IFederalUnitService _serviceFederalUnit;
        private Mock<IFederalUnitService> _serviceMook;
        [Fact(DisplayName="É possivel executar o método GetAll.")]
        public async Task WhenToRunTheGetAllMethod()
        {
            _serviceMook = new Mock<IFederalUnitService>();
            _serviceMook.Setup(m => m.GetAll()).ReturnsAsync(listFederalUnitDto);
            _serviceFederalUnit = _serviceMook.Object;
            var result = await _serviceFederalUnit.GetAll();
            Assert.NotNull(result);
            Assert.True(result.Count() == 10);
            var _listResult = new List<FederalUnitDto>();
            _serviceMook = new Mock<IFederalUnitService>();
            //_serviceMock.Setup(m => m.GetAll()).ReturnsAsync(_listResult.AsEnumerable);
            //_serviceFederalUnit = _serviceMock.Object;
            var _record = await _serviceFederalUnit.GetAll();
            Assert.Empty(_record);
            Assert.True(_record.Count() == 0);
        }
    }
}