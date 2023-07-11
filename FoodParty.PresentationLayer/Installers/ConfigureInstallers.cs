using FoodParty.DomainLayer;
using FoodParty.DomainLayer.Contracts;
using Microsoft.Extensions.Configuration;

namespace FoodParty.PresentationLayer.Installers
{
    public class ConfigureInstallers : IInstaller
    {
        public void InstallServices(IServiceCollection services, IConfiguration configuration, IServiceProvider provider)
        {
            services.Configure<AppSetting>(configuration.GetSection("AppSetting"));

            services.AddMvcCore().AddApiExplorer();
            services.AddControllers();
            services.AddCors();
        }

    }
}
