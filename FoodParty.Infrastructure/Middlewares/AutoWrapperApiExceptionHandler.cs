using AutoWrapper;
using FoodParty.DomainLayer.Contracts;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.Hosting;

namespace FoodParty.Infrastructure.Middlewares
{
    public class AutoWrapperApiExceptionHandler : IConfigureMiddleware
    {
        public int Order { get; private set; } = 1;

        public void Use(IApplicationBuilder app, IHostEnvironment env)
        {
            app.UseApiResponseAndExceptionWrapper(new AutoWrapperOptions
            {
                EnableExceptionLogging = true,
                ShouldLogRequestData = true,
                ShowStatusCode = true,
                UseCamelCaseNamingStrategy = true,
                IsDebug = env.IsDevelopment(),
                IsApiOnly = false,
                WrapWhenApiPathStartsWith = "/api"
            });
        }
    }
}
