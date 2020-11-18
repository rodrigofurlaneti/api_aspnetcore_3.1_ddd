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
        private IRepository<LogEntity> _repository;

        public LogService(IRepository<LogEntity> repository)
        {
            _repository = repository;
        }

        public async Task<bool> Delete(Guid id)
        {
            return await _repository.DeleteAsync(id);
        }

        public async Task<LogEntity> Get(Guid id)
        {
            return await _repository.SelectAsync(id);
        }

        public async Task<IEnumerable<LogEntity>> GetAll()
        {
            return await _repository.SelectAsync();
        }

        public async Task<LogEntity> Post(LogEntity user)
        {
            return await _repository.InsertAsync(user);
        }

        public async Task<LogEntity> Put(LogEntity user)
        {
            return await _repository.UpdateAsync(user);
        }
    }
}
