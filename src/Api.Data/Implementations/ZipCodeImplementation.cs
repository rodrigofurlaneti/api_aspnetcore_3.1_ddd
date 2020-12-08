using System.Threading.Tasks;
using Api.Data.Context;
using Api.Data.Repository;
using Api.Domain.Entities;
using Api.Domain.Repository;
using Microsoft.EntityFrameworkCore;
namespace Api.Data.Implementations
{
    public class ZipCodeImplementation : BaseRepository<ZipCodeEntity>, IZipCodeRepository
    {
        private DbSet<ZipCodeEntity> _dataset;
        public ZipCodeImplementation(MyContext myContext) : base(myContext)
        {
            _dataset = myContext.Set<ZipCodeEntity>();
        }
        public async Task<ZipCodeEntity> SelectAsync(string zipCode)
        {
            return await _dataset.Include(c => c.County).ThenInclude(m => m.FederalUnit).FirstOrDefaultAsync(u => u.ZipCode.Equals(zipCode));
        }
    }
}