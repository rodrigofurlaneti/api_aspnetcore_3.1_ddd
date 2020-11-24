using System;
using System.Threading.Tasks;
using Api.Domain.Dtos;
using Api.Domain.Interfaces.Services.User;
using Moq;
using Xunit;
namespace Api.Service.Test.Action
{
    public class HowToRunningGet : UserTest
    {
        private IUserService _serviceUser;
        private Mock<IUserService> _serviceMook;
        [Fact(DisplayName="É possivel executar o método GET.")]
        public async Task ItIsPossibleToExecuteTheGetMethod()
        {
            _serviceMook = new Mock<IUserService>();
            _serviceMook.Setup(m => m.Get(IdUser)).ReturnsAsync(userDto);
            _serviceUser = _serviceMook.Object;
            var result = await _serviceUser.Get(IdUser);
            Assert.NotNull(result);
            //Assert.True(result.Id == IdUser);
            Assert.Equal(NameCreate, result.Name);

            _serviceMook = new Mock<IUserService>();
            _serviceMook.Setup(m => m.Get(It.IsAny<Guid>())).Returns(Task.FromResult((UserDto) null));
            _serviceUser = _serviceMook.Object;

            var _record = await _serviceUser.Get(IdUser);
            Assert.Null(_record);

        }
    }
}