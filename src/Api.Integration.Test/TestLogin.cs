using System.Threading.Tasks;
using Xunit;
namespace Api.Integration.Test
{
    public class TestLogin : BaseIntegration
    {
        [Fact]
        public async Task MetodoTestLogin()
        {
            await AddToken();
        } 
    }
}