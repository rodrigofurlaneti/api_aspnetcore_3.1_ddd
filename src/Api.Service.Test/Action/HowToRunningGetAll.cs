using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Api.Domain.Dtos;
using Api.Domain.Interfaces.Services.User;
using Moq;
using Xunit;
namespace Api.Service.Test.Action
{
    public class HowToRunningGetAll : UserTest
    {
        private IUserService _serviceUser;
        private Mock<IUserService> _serviceMook;
        [Fact(DisplayName="É possivel executar o método GETALL.")]
        public async Task ItIsPossibleToExecuteTheGetAllMethod()
        {
            _serviceMook = new Mock<IUserService>();
            _serviceMook.Setup(m => m.GetAll()).ReturnsAsync(ListUserDto);
            _serviceUser = _serviceMook.Object;
            var result = await _serviceUser.GetAll();
            Assert.NotNull(result);
            Assert.True(result.Count() == 10);

            List<UserDto> _listResult = new List<UserDto>();
            _serviceMook = new Mock<IUserService>();
            _serviceMook.Setup(m => m.GetAll()).ReturnsAsync(_listResult.AsEnumerable);
            _serviceUser = _serviceMook.Object;
         
            var _recordEmpty = await _serviceUser.GetAll();
            Assert.Empty(_recordEmpty);
            Assert.True(_recordEmpty.Count() == 0);
        }
    }
}