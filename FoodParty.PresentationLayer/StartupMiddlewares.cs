using FoodParty.Infrastructure;
using FoodParty.Infrastructure.Installers;
using FoodParty.PresentationLayer.Installers;

namespace FoodParty.PresentationLayer
{
    public partial class Startup
    {
        private IConfiguration configuration;
        public Startup(IConfiguration configuration)
        {
            this.configuration = configuration;
        }
        public void Configure(IApplicationBuilder app, IHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI(c =>
                {
                    c.SwaggerEndpoint("/swagger/v1/swagger.json", "FoodParty Api v1");
                });
            }

            app.UseMiddlewaresFromInAssemblies(env, configuration, typeof(IInfrustructureMarker).Assembly);

            app.UseRouting();
            app.UseCors("CorsPolicy");
            // app.UseAuthentication();
            // app.UseAuthorization();
            
            app.UseEndpoints(endpointRouteBuilder =>
            {
                endpointRouteBuilder.MapDefaultControllerRoute();
            });

        }
    }
}
