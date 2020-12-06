using System;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using Api.CrossCutting.Mappings;
using Api.Data.Context;
using Api.Domain.Dtos;
using Api.Domain.Login.Dtos;
using Application;
using AutoMapper;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.TestHost;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
namespace Api.Integration.Test
{
    public abstract class BaseIntegration : IDisposable
    {
        public MyContext myContext { get; private set; }
        public HttpClient httpClient { get; private set; }
        public IMapper mapper { get; set; }
        public string hostApi { get; set; }
        public HttpResponseMessage httpResponseMessage { get; set; }
        public BaseIntegration()
        {
            hostApi = "http://localhost:5000/api/";
            var webHostBuilder = new WebHostBuilder().UseEnvironment("Test").UseStartup<Startup>();
            var testServer = new TestServer(webHostBuilder);
            myContext = testServer.Host.Services.GetService(typeof(MyContext)) as MyContext;
            myContext.Database.Migrate();
            mapper = new AutoMapperFixture().GetMapper();
            httpClient = testServer.CreateClient();
        }
        public async Task AddToken()
        {
            LoginDto loginDto = new LoginDto();
            {
                loginDto.Email = "Administrator@system.com";
            };
            var resultLogin = await PostJsonAsync(loginDto, $"{hostApi}login", httpClient);
            var jsonLogin = await resultLogin.Content.ReadAsStringAsync();
            var loginObj = JsonConvert.DeserializeObject<LoginResponseDto>(jsonLogin);
            httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", loginObj.Token);
        }
        public static async Task<HttpResponseMessage> PostJsonAsync(object dataClass, string url, HttpClient httpClient)
        {
            return  await httpClient.PostAsync(url, new StringContent(JsonConvert.SerializeObject(dataClass), System.Text.Encoding.UTF8, "application/json"));
        }
        public void Dispose()
        {
            myContext.Dispose();
            httpClient.Dispose();
        }
    }
    public class AutoMapperFixture : IDisposable
    {
        public IMapper GetMapper()
        {
            var mapperConfiguration = new MapperConfiguration(mapperConfig =>
            {
                mapperConfig.AddProfile(new DtoToModelProfile());
                mapperConfig.AddProfile(new EntityToDtoProfile());
                mapperConfig.AddProfile(new ModelToEntityProfile());
            });
            return mapperConfiguration.CreateMapper();
        }
        public void Dispose(){}
    }
}