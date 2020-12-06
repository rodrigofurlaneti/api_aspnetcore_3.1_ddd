using System.Net;
using System.Threading.Tasks;
using Xunit;
using Api.Domain.Dtos.User;
using System.Net.Http;
using Newtonsoft.Json;
using System;
namespace Api.Integration.Test.User
{
    public class WhenTheUserRequests : BaseIntegration
    {
        private string _name { get; set; }
        private string _email { get; set; }
        [Fact]
        public async Task ItIsPossibleToCrudTheUser()
        {
            await AddToken();
            _name = Faker.Name.First();
            _email = Faker.Internet.Email();
            UserCreateDto userDtoCreate = new UserCreateDto();
            HttpResponseMessage response = await PostJsonAsync(userDtoCreate, $"{hostApi}users", httpClient);
            string postResult = await response.Content.ReadAsStringAsync();
            UserCreateResultDto objectResponsePost = JsonConvert.DeserializeObject<UserCreateResultDto>(postResult);
            Assert.Equal(HttpStatusCode.Created, response.StatusCode);
            Assert.Equal(_name, objectResponsePost.Name);
            Assert.Equal(_email, objectResponsePost.Email);
            Assert.True(objectResponsePost.Id != default(Guid));
        }
    }
}