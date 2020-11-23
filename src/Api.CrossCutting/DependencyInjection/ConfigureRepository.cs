using Api.Data.Context;
using Api.Data.Implementations;
using Api.Data.Repository;
using Api.Domain.Interfaces;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
namespace Api.CrossCutting.DependencyInjection
{
    public class ConfigureRepository
    {
        public static void ConfigureDependenciesRepository(IServiceCollection serviceCollection)
        {
            serviceCollection.AddScoped(typeof(IRepository<>), typeof(BaseRepository<>));
            serviceCollection.AddScoped<IUserRepository, UserImplementation>();
            serviceCollection.AddScoped(typeof(ILogRepository<>), typeof(LogBaseRepository<>));
            serviceCollection.AddScoped<ILogRepository, LogImplementation>();
            serviceCollection.AddDbContext<MyContext>(
                //options => options.UseMySql("Server=localhost;Port=3306;DataBase=world;Uid=root;Pwd=123456")
                options => options.UseSqlServer("Server=.\\SQLSERVER2019;Initial Catalog=dbapi;MultipleActiveResultSets=true;User ID=sa;Password=mudar@123")
            );
        }
    }
}
