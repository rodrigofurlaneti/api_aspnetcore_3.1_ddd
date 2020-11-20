using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Api.Data.Context;
using Api.Domain.Entities;
using Api.Domain.Interfaces;
using Microsoft.EntityFrameworkCore;
namespace Api.Data.Repository
{
    public class LogBaseRepository<T> : ILogRepository<T> where T : LogBaseEntity
    {
        protected readonly MyContext _context;
        private DbSet<T> _dataset;
        public LogBaseRepository(MyContext context)
        {
            _context = context;
            _dataset = _context.Set<T>();
        }
        public async Task<IEnumerable<T>> SelectAsync()
        {
            try
            {
                return await _dataset.ToListAsync();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}