using System.Threading.Tasks;
using Api.Domain.Dtos.Login;
using Api.Domain.Login.Dtos;
namespace Api.Domain.Interfaces.Services
{
    public interface ILoginService
    {
        Task<LoginResponseDto> FindByLoginAsync(string email);
        LoginResponseDto FindByLogin(string email);
    }
}