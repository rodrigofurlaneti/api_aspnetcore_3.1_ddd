using System.Threading.Tasks;
using Api.Domain.Dtos.FederalUnit;
using Api.Domain.Interfaces.Services.FederalUnit;
using Moq;
using Xunit;
using System.Linq;
using System.Collections.Generic;
namespace Api.Service.Test.FederalUnit
{
    public class ToRunningGetAll : FederalUnitTest
    {
        private IFederalUnitService _serviceFederalUnit;
        private Mock<IFederalUnitService> _serviceMock;
        [Fact(DisplayName="É possivel executar o método GetAll.")]
        public async Task WhenToRunTheGetAllMethod()
        {
            _serviceMock = new Mock<IFederalUnitService>();
            _serviceMock.Setup(m => m.GetAll()).ReturnsAsync(listFederalUnitDto);
            _serviceFederalUnit = _serviceMock.Object;
            var result = await _serviceFederalUnit.GetAll();
            Assert.NotNull(result);
            Assert.True(result.Count() == 10);
            var _listResult = new List<FederalUnitDto>();
            _serviceMock = new Mock<IFederalUnitService>();
            _serviceMock.Setup(m => m.GetAll()).ReturnsAsync(_listResult.AsEnumerable);
            _serviceFederalUnit = _serviceMock.Object;
            var _record = await _serviceFederalUnit.GetAll();
            Assert.Empty(_record);
            Assert.True(_record.Count() == 0);
        }
    }
}