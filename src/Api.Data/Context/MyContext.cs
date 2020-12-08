using System;
using Api.Data.Mapping;
using Api.Data.Seeds;
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
            modelBuilder.Entity<FederalUnitEntity>(new FederalUnitMap().Configure);
            modelBuilder.Entity<CountyEntity>(new CountyMap().Configure);
            modelBuilder.Entity<ZipCodeEntity>(new ZipCodeMap().Configure);
            modelBuilder.Entity<UserEntity>().HasData(
                new UserEntity
                {
                    Id = Guid.NewGuid(),
                    Name = "Administrator",
                    Email = "Administrator@system.com",
                    CreateAt = DateTime.Now,
                    UpdateAt = DateTime.Now
                }
            );
            FederalUnitSeeds.FederalUnits(modelBuilder);
        }
    }
}
