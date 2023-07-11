using FoodParty.BussinessLayer.DealProjects;
using FoodParty.DomainLayer.Contracts;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace FoodParty.BussinessLayer
{
    public class RuleInstaller : IInstaller
    {
        public void InstallServices(IServiceCollection services, IConfiguration configuration, IServiceProvider provider)
        {
            services.AddScoped<IDealProjectRule, DealProjectRule>();
        }
    }
}
