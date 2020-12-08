using System;
using System.Threading.Tasks;
using Api.Data.Context;
using Api.Data.Repository;
using Api.Domain.Entities;
using Api.Domain.Repository;
using Microsoft.EntityFrameworkCore;
namespace Api.Data.Implementations
{
    public class CountyImplementation : BaseRepository<CountyEntity>, ICountyRepository
    {
        private DbSet<CountyEntity> _dataset;
        public CountyImplementation(MyContext myContext) : base(myContext)
        {
            _dataset = myContext.Set<CountyEntity>();
        }
        public async Task<CountyEntity> GetCompleteByIbgeAsync(int codeIbge)
        {
            return await _dataset.Include(m => m.FederalUnit).FirstOrDefaultAsync(m => m.CodeIbge.Equals(codeIbge));
        }
        public async Task<CountyEntity> GetCompleteByIdAsync(Guid id)
        {
            return await _dataset.Include(m => m.FederalUnit).FirstOrDefaultAsync(m => m.CodeIbge.Equals(id));
        }
    }
}