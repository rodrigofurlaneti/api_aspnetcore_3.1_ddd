using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Api.Domain.Entities;
using Api.Domain.Interfaces;
using Api.Domain.Interfaces.Services.Log;
namespace Api.Service.Services
{
    public class LogService : ILogService
    {
        private ILogRepository<LogEntity> _repository;

        public LogService(ILogRepository<LogEntity> repository)
        {
            _repository = repository;
        }
        public async Task<IEnumerable<LogEntity>> GetAll()
        {
            return await _repository.SelectAsync();
        }
    }
}
