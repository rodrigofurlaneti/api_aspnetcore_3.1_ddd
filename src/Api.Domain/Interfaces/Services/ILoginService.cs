using System.Threading.Tasks;
using Api.Domain.Entities;
namespace Api.Domain.Interfaces.Services
{
    public interface ILoginService
    {
         Task<UserEntity> FindByLogin(string email, string hostName, string ipv6, string ipv4);
    }
}