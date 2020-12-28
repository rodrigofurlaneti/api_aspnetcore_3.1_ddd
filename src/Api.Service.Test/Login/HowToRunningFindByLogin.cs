using System;
using System.Threading.Tasks;
using Api.Domain.Dtos.Login;
using Api.Domain.Entities;
using Api.Domain.Interfaces.Services;
using Api.Service.Test.User;
using Moq;
using Xunit;
namespace Api.Service.Test.Login
{
    public class HowToRunningFindByLogin : UserTest
    {
        private ILoginService _serviceLogin;
        private Mock<ILoginService> _serviceMock;
        [Fact(DisplayName="É possivel executar o método FINDBYLOGIN.")]
        public async Task ItIsPossibleToExecuteTheFindByLoginMethod()
        {
            LoginResponseDto objectReturn = new LoginResponseDto(); 
            objectReturn.Name = Faker.Name.FullName();
            objectReturn.Email = Faker.Internet.Email();
            objectReturn.Authenticated = true;
            objectReturn.Message = Faker.ISOCountryCode.Next();
            objectReturn.CreateAt = DateTime.Now;
            objectReturn.Expiration = DateTime.Now.AddHours(8);
            objectReturn.Token = Faker.Internet.DomainName();

            UserEntity userEntity = new UserEntity();
            userEntity.Email = objectReturn.Email;
            
            _serviceMock = new Mock<ILoginService>();
            _serviceMock.Setup(m => m.FindByLoginAsync(userEntity.Email)).ReturnsAsync(objectReturn);
            _serviceLogin = _serviceMock.Object;

            LoginResponseDto result = await _serviceLogin.FindByLoginAsync(userEntity.Email);
            Assert.NotNull(result);
        }
    }
}