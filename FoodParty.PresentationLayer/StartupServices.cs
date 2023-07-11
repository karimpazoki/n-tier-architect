using FoodParty.DomainLayer.Contracts;
using FoodParty.PresentationLayer.Installers;
using Microsoft.Extensions.Configuration;
using System.Reflection;
using System.Security.AccessControl;
using FoodParty.BussinessLayer;
using FoodParty.DataAccessLayer;
using FoodParty.PresentationLayer.Installers;

namespace FoodParty.PresentationLayer
{
    public partial class Startup
    {
        public void ConfigureServices(IServiceCollection services)
        {
            ServiceProvider provider = services.BuildServiceProvider();
            // List<Assembly> list = new List<Assembly>() { typeof(IEntity).Assembly };
            //         
            // IEnumerable<Type> types = list.SelectMany(e => e.GetExportedTypes())
            //      .Where(e => e.IsClass && !e.IsAbstract  && e.IsPublic && typeof(IEntity).IsAssignableFrom(e));
            services.InstallServicesInAssemblies(provider, configuration, typeof(Startup).Assembly,typeof(DataInstaller).Assembly,typeof(RuleInstaller).Assembly);

        }
    }
}
