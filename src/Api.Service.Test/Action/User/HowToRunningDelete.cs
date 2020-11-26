using System;
using System.Threading.Tasks;
using Api.Domain.Interfaces.Services.User;
using Moq;
using Xunit;
namespace Api.Service.Test.Action.User
{
    public class HowToRunningDelete : UserTest
    {
        private IUserService _serviceUser;
        private Mock<IUserService> _serviceMook;
        [Fact(DisplayName="É possivel executar o método DELETE.")]
        public async Task ItIsPossibleToExecuteTheDeleteMethod()
        {
            _serviceMook = new Mock<IUserService>();
            _serviceMook.Setup(m => m.Delete(It.IsAny<Guid>())).ReturnsAsync(true);
            _serviceUser = _serviceMook.Object;
            
            bool wipedOut = await _serviceUser.Delete(idCreate);
            Assert.True(wipedOut);

            _serviceMook = new Mock<IUserService>();
            _serviceMook.Setup(m => m.Delete(It.IsAny<Guid>())).ReturnsAsync(false);
            _serviceUser = _serviceMook.Object;

            wipedOut = await _serviceUser.Delete(Guid.NewGuid());
            Assert.False(wipedOut);
        }
    }
}