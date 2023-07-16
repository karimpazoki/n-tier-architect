using FoodParty.BussinessLayer.DealProjects;
using FoodParty.Infrastructure.Installers;

namespace FoodParty.PresentationLayer.Installers
{
    public class RuleInstaller : IInstaller
    {
        public void InstallServices(IServiceCollection services, IConfiguration configuration, IServiceProvider provider)
        {
            services.AddScoped<IDealProjectRule, DealProjectRule>();
        }
    }
}
