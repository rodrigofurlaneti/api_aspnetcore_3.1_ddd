using System;
using Api.Data.Context;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
namespace Api.Data.Test.Base
{
    public class DbTest : IDisposable
    {
        private string _dataBaseName = $"dbApiTest_{Guid.NewGuid().ToString().Replace("-", string.Empty)}";
        public ServiceProvider serviceProvider { get; private set;}
        public DbTest()
        {
            ServiceCollection serviceCollection = new ServiceCollection();
            serviceCollection.AddDbContext<MyContext>(o => 
            o.UseSqlServer($"Server=.\\SQLSERVER2019;Initial Catalog={_dataBaseName};MultipleActiveResultSets=true;User ID=sa;Password=mudar@123"),
            ServiceLifetime.Transient
            );
            serviceProvider = serviceCollection.BuildServiceProvider();
            using(var context = serviceProvider.GetService<MyContext>())
            {
                context.Database.EnsureCreated();
            }
        }
        public void Dispose()
        {
        using(var context = serviceProvider.GetService<MyContext>())
            {
                context.Database.EnsureDeleted();
            }
        }
    }
}