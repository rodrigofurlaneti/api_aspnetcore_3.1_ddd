using System;
using System.Threading.Tasks;
using Api.Domain.Entities;
using Api.Domain.Interfaces;
namespace Api.Domain.Repository
{
    public interface ICountyRepository : IRepository<CountyEntity>
    {
         Task<CountyEntity> GetCompleteByIdAsync(Guid id);
         Task<CountyEntity> GetCompleteByIbgeAsync(int codeIbge);         
    }
}