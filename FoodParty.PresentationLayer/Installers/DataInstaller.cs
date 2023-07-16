using FoodParty.DataAccessLayer;
using FoodParty.DomainLayer;
using FoodParty.DomainLayer.Contracts;
using FoodParty.DomainLayer.Contracts;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using FoodParty.DomainLayer.Enums;
using FoodParty.Infrastructure.Installers;

namespace FoodParty.PresentationLayer.Installers
{
    public class DataInstaller : IInstaller
    {
        public void InstallServices(IServiceCollection services, IConfiguration configuration, IServiceProvider provider)
        {
            services.AddDbContextPool<AppDbContext>(options =>
            {
                var settings = configuration.GetSection("AppSetting").Get<AppSetting>();
                
                switch (settings?.DbConnectionType)
                {
                    case DbConnectionType.Mysql:
                        options.UseMySQL(
                            settings?.ConnectionStrings?.MySqlConnection
                        );
                        break;
                    case DbConnectionType.SqlServer:
                        options.UseSqlServer(
                             settings?.ConnectionStrings?.SqlServerConnection
                        );
                        break;
                    default:
                        // TODO: throw DB Exception from exception handler
                        break;
                }
            });
            services.AddScoped(typeof(IRepository<>),typeof(EfCoreRepository<>));
        }
    }
}
