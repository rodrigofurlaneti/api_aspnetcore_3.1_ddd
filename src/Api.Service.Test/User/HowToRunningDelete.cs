using System;
using System.Threading.Tasks;
using Api.Domain.Interfaces.Services.User;
using Moq;
using Xunit;
namespace Api.Service.Test.User
{
    public class HowToRunningDelete : UserTest
    {
        private IUserService _serviceUser;
        private Mock<IUserService> _serviceMock;
        [Fact(DisplayName="É possivel executar o método DELETE.")]
        public async Task ItIsPossibleToExecuteTheDeleteMethod()
        {
            _serviceMock = new Mock<IUserService>();
            _serviceMock.Setup(m => m.Delete(It.IsAny<Guid>())).ReturnsAsync(true);
            _serviceUser = _serviceMock.Object;
            
            bool wipedOut = await _serviceUser.Delete(idCreate);
            Assert.True(wipedOut);

            _serviceMock = new Mock<IUserService>();
            _serviceMock.Setup(m => m.Delete(It.IsAny<Guid>())).ReturnsAsync(false);
            _serviceUser = _serviceMock.Object;

            wipedOut = await _serviceUser.Delete(Guid.NewGuid());
            Assert.False(wipedOut);
        }
    }
}