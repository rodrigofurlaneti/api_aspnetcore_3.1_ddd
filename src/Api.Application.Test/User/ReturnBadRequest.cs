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
    public class ReturnBadRequest
    {
        private UsersController _usersController;
        [Fact(DisplayName = "É possivel realizar a BADREQUEST.")]
        public async Task ItIsPossibleToInvokeTheBadRequestController()
        {
            Mock<IUserService> serviceMock = new Mock<IUserService>();
            string _name = Faker.Name.FullName();
            string _email = Faker.Internet.Email();
            serviceMock.Setup(m => m.Post(It.IsAny<UserCreateDto>())).ReturnsAsync(
                new UserCreateResultDto
                {
                    Id = Guid.NewGuid(),
                    Name = _name,
                    Email = _email, 
                    CreateAt = DateTime.Now
                }
            );

            _usersController = new UsersController(serviceMock.Object);
            _usersController.ModelState.AddModelError("Name", "É um campo obrigatório");
            Mock<IUrlHelper> url = new Mock<IUrlHelper>();
            url.Setup(x => x.Link(It.IsAny<string>(), It.IsAny<object>())).Returns("http://localhost:5000");
            _usersController.Url = url.Object;
            UserCreateDto userCreateDto = new UserCreateDto
            {
                Name = _name,
                Email = _email
            };
            ActionResult actionResult = await _usersController.Post(userCreateDto);
            Assert.True(actionResult is BadRequestObjectResult);
        }
    }
}