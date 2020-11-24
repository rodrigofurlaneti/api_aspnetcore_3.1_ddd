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
        [Fact(DisplayName="É possivel executar o método PUT.")]
        public async Task ItIsPossibleToExecuteThePutMethod()
        {
            _serviceMook = new Mock<IUserService>();
            _serviceMook.Setup(m => m.Post(userCreateDto)).ReturnsAsync(userCreateResultDto);
            _serviceUser = _serviceMook.Object;
            
            var result = await _serviceUser.Post(userCreateDto);
            Assert.NotNull(result);
            Assert.Equal(nameCreate, result.Name);
            Assert.Equal(emailCreate, result.Email);

            _serviceMook = new Mock<IUserService>();
            _serviceMook.Setup(m => m.Put(userUpdateDto)).ReturnsAsync(userUpdateResultDto);
            _serviceUser = _serviceMook.Object;

            var _resultUpdate = await _serviceUser.Put(userUpdateDto);
            Assert.NotNull(_resultUpdate);
            Assert.Equal(nameUpdate, _resultUpdate.Name);
            Assert.Equal(emailUpdate, _resultUpdate.Email);
        }
    }
}