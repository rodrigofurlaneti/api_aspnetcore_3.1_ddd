using System.Net.Http;
using Api.Data.Context;
using AutoMapper;
namespace Api.Integration.Test
{
    public class BaseIntegration
    {
        public MyContext myContext { get; private set; }
        public HttpClient httpClient { get; private set; }
        public IMapper mapper { get; set; }
        public string hostApi { get; set; }
        public HttpResponseMessage httpResponseMessage { get; set; }
        public BaseIntegration()
        {
            hostApi = "http://localhost:5000/Api";
            WebHostBuild webHostBuild = new WebHostBuild().UseEnvironment("Testing").UseStartup<Startup>();
            TestServer testServer = new TestServer(webHostBuild);
            myContext = testServer.Host.Services.GetService(typeof(MyContext)) as MyContext;
            myContext.Database.Migrate();
            mapper = new 
        }
    }
}