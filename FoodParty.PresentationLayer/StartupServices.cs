using FoodParty.DomainLayer.Contracts;
using FoodParty.Infrastructure.Installers;
using Microsoft.Extensions.Configuration;
using System.Reflection;
using System.Security.AccessControl;
using FoodParty.BussinessLayer;
using FoodParty.DataAccessLayer;
using FoodParty.Infrastructure.Installers;
using FoodParty.PresentationLayer.Installers;

namespace FoodParty.PresentationLayer
{
    public partial class Startup
    {
        public void ConfigureServices(IServiceCollection services)
        {
            // TODO: remove provider to avoid to duplicate singleton services
            // services.Clear();
            ServiceProvider provider = services.BuildServiceProvider();
            
            services.InstallServicesInAssemblies(provider, configuration, typeof(Startup).Assembly,typeof(DataInstaller).Assembly,typeof(RuleInstaller).Assembly);
            
        }
    }
}
