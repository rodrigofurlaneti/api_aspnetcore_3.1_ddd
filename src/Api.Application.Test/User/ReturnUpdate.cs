using System;
using System.Threading.Tasks;
using Api.Application.Controllers;
using Api.Domain.Dtos.User;
using Api.Domain.Interfaces.Services.User;
using Microsoft.AspNetCore.Mvc;
using Moq;
using Xunit;
namespace Api.Application.Test.User
{
    public class ReturnUpdate
    {
        private UsersController _usersController;
        [Fact(DisplayName = "É possivel realizar a UPDATE.")]
        public async Task ItIsPossibleToInvokeTheUpdateController()
        {
            Mock<IUserService> serviceMock = new Mock<IUserService>();
            string _name = Faker.Name.FullName();
            string _email = Faker.Internet.Email();
            serviceMock.Setup(m => m.Put(It.IsAny<UserUpdateDto>())).ReturnsAsync(
                new UserUpdateResultDto
                {
                    Id = Guid.NewGuid(),
                    Name = _name,
                    Email = _email, 
                    UpdateAt = DateTime.Now
                }
            );
            _usersController = new UsersController(serviceMock.Object);
            UserUpdateDto userUpdateDto = new UserUpdateDto
            {
                Id = Guid.NewGuid(),
                Name = _name,
                Email = _email
            };
            ActionResult actionResult = await _usersController.Put(userUpdateDto);
            Assert.True(actionResult is OkObjectResult);

            UserUpdateResultDto userUpdateResultDtoValue = ((OkObjectResult)actionResult).Value as UserUpdateResultDto;
            Assert.NotNull(userUpdateResultDtoValue);
            Assert.Equal(userUpdateDto.Name, userUpdateResultDtoValue.Name);
            Assert.Equal(userUpdateDto.Email, userUpdateResultDtoValue.Email);
 
            
        }
    }
}