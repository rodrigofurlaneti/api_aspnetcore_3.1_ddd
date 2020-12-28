using System.Threading.Tasks;
using Api.Domain.Dtos.User;
using Api.Domain.Interfaces.Services.User;
using Moq;
using Xunit;
namespace Api.Service.Test.User
{
    public class HowToRunningPut : UserTest
    {
        private IUserService _serviceUser;
        private Mock<IUserService> _serviceMock;
        [Fact(DisplayName="É possivel executar o método PUT.")]
        public async Task ItIsPossibleToExecuteThePutMethod()
        {
            _serviceMock = new Mock<IUserService>();
            _serviceMock.Setup(m => m.Post(userCreateDto)).ReturnsAsync(userCreateResultDto);
            _serviceUser = _serviceMock.Object;
            
            UserCreateResultDto result = await _serviceUser.Post(userCreateDto);
            Assert.NotNull(result);
            Assert.Equal(nameCreate, result.Name);
            Assert.Equal(emailCreate, result.Email);

            _serviceMock = new Mock<IUserService>();
            _serviceMock.Setup(m => m.Put(userUpdateDto)).ReturnsAsync(userUpdateResultDto);
            _serviceUser = _serviceMock.Object;

            UserUpdateResultDto _resultUpdate = await _serviceUser.Put(userUpdateDto);
            Assert.NotNull(_resultUpdate);
            Assert.Equal(result.Name, _resultUpdate.Name);
            Assert.Equal(result.Email, _resultUpdate.Email);
        }
    }
}