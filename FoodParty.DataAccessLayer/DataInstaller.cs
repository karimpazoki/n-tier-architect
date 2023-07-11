using FoodParty.DomainLayer;
using FoodParty.DomainLayer.Contracts;
using FoodParty.DomainLayer.Contract;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using FoodParty.DomainLayer.Enums;

namespace FoodParty.DataAccessLayer
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
                    case DBConnectionType.Mysql:
                        options.UseMySQL(
                            settings?.ConnectionStrings.MySqlConnection
                        );
                        break;
                    case DBConnectionType.SqlServer:
                        options.UseSqlServer(
                             settings?.ConnectionStrings?.SqlServerConnection
                        );
                        break;
                }
            });
            services.AddScoped(typeof(IAppStore<>),typeof(EFCoreAppStore<>));
        }
    }
}
