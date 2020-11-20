using System.Threading.Tasks;
using Api.Domain.Entities;
namespace Api.Domain.Interfaces
{
    public interface ILogRepository : ILogRepository<LogEntity>
    {
        void CreateLog (UserEntity user);
        Task<LogEntity> CreateLogAsync (UserEntity user, string hostName, string ipv6, string ipv4);
    }
}