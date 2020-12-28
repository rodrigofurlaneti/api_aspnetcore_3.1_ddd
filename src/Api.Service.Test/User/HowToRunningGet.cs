using System;
using System.Threading.Tasks;
using Api.Domain.Dtos;
using Api.Domain.Interfaces.Services.User;
using Moq;
using Xunit;
namespace Api.Service.Test.User
{
    public class HowToRunningGet : UserTest
    {
        private IUserService _serviceUser;
        private Mock<IUserService> _serviceMock;
        [Fact(DisplayName="É possivel executar o método GET.")]
        public async Task ItIsPossibleToExecuteTheGetMethod()
        {
            _serviceMock = new Mock<IUserService>();
            _serviceMock.Setup(m => m.Get(idCreate)).ReturnsAsync(userDto);
            _serviceUser = _serviceMock.Object;
            UserDto result = await _serviceUser.Get(idCreate);
            Assert.NotNull(result);
            Assert.Equal(nameCreate, result.Name);

            _serviceMock = new Mock<IUserService>();
            _serviceMock.Setup(m => m.Get(It.IsAny<Guid>())).Returns(Task.FromResult((UserDto) null));
            _serviceUser = _serviceMock.Object;

            UserDto _record = await _serviceUser.Get(idCreate);
            Assert.Null(_record);
        }
    }
}