using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.Hosting;

namespace FoodParty.DomainLayer.Contracts
{
    public interface IConfigureMiddleware
    {
        public int Order { get; }
        void Use(IApplicationBuilder app, IHostEnvironment env);
    }
}
