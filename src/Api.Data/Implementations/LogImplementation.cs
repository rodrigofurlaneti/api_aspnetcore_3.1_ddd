using System.Data;
using System;
using System.Threading.Tasks;
using Api.Data.Context;
using Api.Data.Repository;
using Api.Domain.Entities;
using Api.Domain.Interfaces;
using Microsoft.EntityFrameworkCore;
namespace Api.Data.Implementations
{
    public class LogImplementation : BaseRepository<LogEntity>, ILogRepository
    {
        private DbSet<LogEntity> _dataset;
        public LogImplementation(MyContext context) : base (context)
        {
            _dataset = _context.Set<LogEntity>();
        }
        public void CreateLog(UserEntity user)
        {
            LogEntity log = new LogEntity();
            if (user.Id == Guid.Empty)
            {
                log.Id = Guid.NewGuid();
                log.CreateAt = DateTime.Now;
                log.UpdateAt = DateTime.Now;
                log.Authenticated = user.Authenticated;
                log.Message = user.Message;
                log.Token = "Não existe";
                log.Expiration = DateTime.Now;
                log.Name = "Não autenticado";
                log.Email = user.Email;
            }
            else
            {
                log.Id = user.Id;
                log.CreateAt = DateTime.Now;
                log.UpdateAt = DateTime.Now;
                log.Authenticated = true;
                log.Message = user.Message;
                log.Token = user.Token;
                log.Expiration = user.Expiration;
                log.Name = user.Name;
                log.Email = user.Email;
            }   
            try
            {
                _dataset.Add(log);
                _context.SaveChanges();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
     }
}