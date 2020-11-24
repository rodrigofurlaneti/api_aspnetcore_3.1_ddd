using System;
using System.Threading.Tasks;
using Api.Domain.Dtos;
using Api.Domain.Interfaces.Services.User;
using Moq;
using Xunit;
namespace Api.Service.Test.Action
{
    public class HowToRunningPut : UserTest
    {
        private IUserService _serviceUser;
        private Mock<IUserService> _serviceMook;
        [Fact(DisplayName="É possivel executar o método CREATE.")]
        public async Task ItIsPossibleToExecuteThePutMethod()
        {
            _serviceMook = new Mock<IUserService>();
            _serviceMook.Setup(m => m.Post(userDto)).ReturnsAsync(userCreateResultDto);
            _serviceUser = _serviceMook.Object;
            
            var result = await _serviceUser.Put(userDto);
            Assert.NotNull(result);
            Assert.Equal(nameCreate, result.Name);

            _serviceMook = new Mock<IUserService>();
            _serviceMook.Setup(m => m.Get(It.IsAny<Guid>())).Returns(Task.FromResult((UserDto) null));
            _serviceUser = _serviceMook.Object;

            var _record = await _serviceUser.Get(idCreate);
            Assert.Null(_record);
        }
    }
}