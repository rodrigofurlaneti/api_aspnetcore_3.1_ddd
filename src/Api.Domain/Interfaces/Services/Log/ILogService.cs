using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Api.Domain.Entities;
namespace Api.Domain.Interfaces.Services.Log
{
    public interface ILogService
    {
        Task<LogEntity> Get(Guid id);
        Task<IEnumerable<LogEntity>> GetAll();
        Task<LogEntity> Post(LogEntity user);
        Task<LogEntity> Put(LogEntity user);
        Task<bool> Delete(Guid id);
    }
}
