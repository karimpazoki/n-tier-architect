using FoodParty.Infrastructure;
using FoodParty.PresentationLayer.Installers;
using System.Reflection;

namespace FoodParty.PresentationLayer
{
    public partial class Startup
    {
        public IConfiguration configuration;
        public Startup(IConfiguration configuration)
        {
            this.configuration = configuration;
        }
        public void Configure(IApplicationBuilder app, IHostEnvironment env)
        {
            if (env.EnvironmentName.Equals("Development"))
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI(c =>
                {
                    c.SwaggerEndpoint("/swagger/v1/swagger.json", "FoodParty Api v1");
                });
            }
            app.UseStaticFiles();

            app.UseMiddlewaresFromInAssemblies(env,configuration, typeof(IMarker).Assembly);

            // app.UseStaticFiles();


            app.UseRouting();
            app.UseCors("CorsPolicy");
            //app.UseAuthentication();
            //app.UseAuthorization();
            //app.UseElmah();
            app.UseEndpoints(cfg =>
            {
                cfg.MapDefaultControllerRoute();
            });

        }
    }
}
