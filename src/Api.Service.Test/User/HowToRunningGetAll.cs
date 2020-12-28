using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Api.Domain.Dtos;
using Api.Domain.Dtos.User;
using Api.Domain.Interfaces.Services.User;
using Moq;
using Xunit;
namespace Api.Service.Test.User
{
    public class HowToRunningGetAll : UserTest
    {
        private IUserService _serviceUser;
        private Mock<IUserService> _serviceMock;
        [Fact(DisplayName="É possivel executar o método GETALL.")]
        public async Task ItIsPossibleToExecuteTheGetAllMethod()
        {
            _serviceMock = new Mock<IUserService>();
            _serviceMock.Setup(m => m.GetAll()).ReturnsAsync(listUserDto);
            _serviceUser = _serviceMock.Object;
            IEnumerable<UserDto> result = await _serviceUser.GetAll();
            Assert.NotNull(result);
            Assert.True(result.Count() == 10);

            List<UserDto> _listResult = new List<UserDto>();
            _serviceMock = new Mock<IUserService>();
            _serviceMock.Setup(m => m.GetAll()).ReturnsAsync(_listResult.AsEnumerable);
            _serviceUser = _serviceMock.Object;
         
            IEnumerable<UserDto> _recordEmpty = await _serviceUser.GetAll();
            Assert.Empty(_recordEmpty);
            Assert.True(_recordEmpty.Count() == 0);
        }
    }
}