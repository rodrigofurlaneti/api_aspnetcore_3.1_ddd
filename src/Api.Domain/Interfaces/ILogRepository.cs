using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Api.Domain.Entities;
namespace Api.Domain.Interfaces
{
    public interface ILogRepository<T> where T : LogBaseEntity
    {
        Task<IEnumerable<T>> SelectAsync();
    }
}