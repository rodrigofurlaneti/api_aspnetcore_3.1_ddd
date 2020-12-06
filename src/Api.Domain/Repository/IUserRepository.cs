using System.Threading.Tasks;
using Api.Domain.Entities;
namespace Api.Domain.Interfaces
{
    public interface IUserRepository : IRepository<UserEntity>
    {
         Task<UserEntity> FindByLoginAsync (string email);
         
         UserEntity FindByLogin (string email);
    }
}