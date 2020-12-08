using Api.Data.Context;
using Api.Data.Repository;
using Api.Domain.Entities;
using Api.Domain.Repository;
using Microsoft.EntityFrameworkCore;
namespace Api.Data.Implementations
{
    public class FederalUnitImplementation : BaseRepository<FederalUnitEntity>, IFederalUnitRepository
    {
        private DbSet<FederalUnitEntity> _dataset;
        public FederalUnitImplementation(MyContext myContext) : base(myContext)
        {
            _dataset = myContext.Set<FederalUnitEntity>();
        }

    }
}