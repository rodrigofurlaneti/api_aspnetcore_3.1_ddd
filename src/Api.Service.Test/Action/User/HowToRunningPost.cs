using System;
using System.Threading.Tasks;
using Api.Domain.Dtos.User;
using Api.Domain.Interfaces.Services.User;
using Moq;
using Xunit;
namespace Api.Service.Test.Action.User
{
    public class HowToRunningPost : UserTest
    {
        private IUserService _serviceUser;
        private Mock<IUserService> _serviceMook;
        [Fact(DisplayName="É possivel executar o método POST.")]
        public async Task ItIsPossibleToExecuteThePostMethod()
        {
            _serviceMook = new Mock<IUserService>();
            _serviceMook.Setup(m => m.Post(userCreateDto)).ReturnsAsync(userCreateResultDto);
            _serviceUser = _serviceMook.Object;
            
            UserCreateResultDto result = await _serviceUser.Post(userCreateDto);
            Assert.NotNull(result);
            Assert.Equal(nameCreate, result.Name);
            Assert.Equal(emailCreate, result.Email);
        }
    }
}