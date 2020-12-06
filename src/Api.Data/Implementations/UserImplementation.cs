using System.Linq;
using System.Threading.Tasks;
using Api.Data.Context;
using Api.Data.Repository;
using Api.Domain.Entities;
using Api.Domain.Interfaces;
using Microsoft.EntityFrameworkCore;
namespace Api.Data.Implementations
{
    public class UserImplementation : BaseRepository<UserEntity>, IUserRepository
    {
        private DbSet<UserEntity> _dataset;
        public UserImplementation(MyContext context) : base (context)
        {
            _dataset = _context.Set<UserEntity>();
        }
        public UserEntity FindByLogin(string email)
        {
            return _dataset.FirstOrDefault(u => u.Email.Equals(email));        
        }
        public async Task<UserEntity> FindByLoginAsync(string email)
        {
            return await _dataset.FirstOrDefaultAsync(u => u.Email.Equals(email));
        }
    }
}