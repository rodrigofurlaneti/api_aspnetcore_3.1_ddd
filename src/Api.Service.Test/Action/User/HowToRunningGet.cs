using System;
using System.Threading.Tasks;
using Api.Domain.Dtos;
using Api.Domain.Interfaces.Services.User;
using Moq;
using Xunit;
namespace Api.Service.Test.Action.User
{
    public class HowToRunningGet : UserTest
    {
        private IUserService _serviceUser;
        private Mock<IUserService> _serviceMook;
        [Fact(DisplayName="É possivel executar o método GET.")]
        public async Task ItIsPossibleToExecuteTheGetMethod()
        {
            _serviceMook = new Mock<IUserService>();
            _serviceMook.Setup(m => m.Get(idCreate)).ReturnsAsync(userDto);
            _serviceUser = _serviceMook.Object;
            UserDto result = await _serviceUser.Get(idCreate);
            Assert.NotNull(result);
            Assert.Equal(nameCreate, result.Name);

            _serviceMook = new Mock<IUserService>();
            _serviceMook.Setup(m => m.Get(It.IsAny<Guid>())).Returns(Task.FromResult((UserDto) null));
            _serviceUser = _serviceMook.Object;

            UserDto _record = await _serviceUser.Get(idCreate);
            Assert.Null(_record);
        }
    }
}