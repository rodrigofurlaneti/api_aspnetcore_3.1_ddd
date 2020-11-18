using System.Threading.Tasks;
using Api.Domain.Entities;
namespace Api.Domain.Interfaces
{
    public interface ILogRepository : IRepository<LogEntity>
    {
        void CreateLog (UserEntity user);
    }
}