using System;
using Api.Data.Mapping;
using Api.Domain.Entities;
using Microsoft.EntityFrameworkCore;
namespace Api.Data.Context
{
    public class MyContext : DbContext
    {
        public DbSet<UserEntity> User { get; set; }
        public MyContext(DbContextOptions<MyContext> options) : base(options){}
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<UserEntity>(new UserMap().Configure);
            modelBuilder.Entity<UserEntity>().HasData(
                new UserEntity
                {
                    Id = Guid.NewGuid(),
                    Name = "Administrator",
                    Email = "Administrator@system.com",
                    Authenticated = true,
                    CreateAt = DateTime.Now,
                    UpdateAt = DateTime.Now
                }
            );
            modelBuilder.Entity<UserEntity>(new UserMap().Configure);
        }
    }
}
