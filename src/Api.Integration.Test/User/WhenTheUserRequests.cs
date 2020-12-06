using System.Net;
using System.Threading.Tasks;
using Xunit;
using Api.Domain.Dtos.User;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using Api.Domain.Dtos;
using System.Linq;
using System.Text;
using System.Net.Http;

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
            var userDtoCreate = new UserCreateDto()
            {
                Name = _name,
                Email = _email
            };
            var response = await PostJsonAsync(userDtoCreate, $"{hostApi}users", httpClient);
            var postResult = await response.Content.ReadAsStringAsync();
            var objectResponsePost = JsonConvert.DeserializeObject<UserCreateResultDto>(postResult);
            Assert.Equal(HttpStatusCode.Created, response.StatusCode);
            Assert.Equal(_name, objectResponsePost.Name);
            Assert.Equal(_email, objectResponsePost.Email);
            Assert.True(objectResponsePost.Id != default(Guid));
            //GetAll();
            response = await httpClient.GetAsync($"{hostApi}users");
            Assert.Equal(HttpStatusCode.OK, response.StatusCode);
            var jsonResult = await response.Content.ReadAsStringAsync();
            var listObjectJson = JsonConvert.DeserializeObject<IEnumerable<UserDto>>(jsonResult);
            Assert.NotNull(listObjectJson);
            Assert.True(listObjectJson.Count() > 0);
            Assert.True(listObjectJson.Where(r => r.Id == objectResponsePost.Id).Count() == 1);
            //Put
            UserUpdateDto userUpdateDto = new UserUpdateDto()
            {
                Id = objectResponsePost.Id,
                Name = Faker.Name.FullName(),
                Email = Faker.Internet.Email()
            };
            var stringContent = new StringContent(JsonConvert.SerializeObject(userUpdateDto),Encoding.UTF8, "application/json");
            response = await httpClient.PutAsync($"{hostApi}users", stringContent);
            jsonResult = await response.Content.ReadAsStringAsync();
            var objectResponsePut = JsonConvert.DeserializeObject<UserUpdateResultDto>(jsonResult);
            Assert.Equal(HttpStatusCode.OK, response.StatusCode);
            Assert.NotEqual(objectResponsePost.Name, objectResponsePut.Name);
            Assert.NotEqual(objectResponsePost.Email, objectResponsePut.Email);
            //Get id
            response = await httpClient.GetAsync($"{hostApi}users/{objectResponsePut.Id}");
            Assert.Equal(HttpStatusCode.OK, response.StatusCode);
            jsonResult = await response.Content.ReadAsStringAsync();
            var objectResponseGetId = JsonConvert.DeserializeObject<UserDto>(jsonResult);
            Assert.NotNull(objectResponseGetId);
            Assert.Equal(objectResponseGetId.Name, objectResponsePut.Name);
            Assert.Equal(objectResponseGetId.Email, objectResponsePut.Email);
            //Delete
            response = await httpClient.DeleteAsync($"{hostApi}users/{objectResponseGetId.Id}");
            Assert.Equal(HttpStatusCode.OK, response.StatusCode);
            //Get id after delete
            response = await httpClient.GetAsync($"{hostApi}users/{objectResponseGetId.Id}");
            Assert.Equal(HttpStatusCode.NotFound, response.StatusCode);
        }
    }
}