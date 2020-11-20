using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Api.Domain.Entities;
namespace Api.Domain.Interfaces.Services.Log
{
    public interface ILogService
    {
        Task<IEnumerable<LogEntity>> GetAll();
    }
}
