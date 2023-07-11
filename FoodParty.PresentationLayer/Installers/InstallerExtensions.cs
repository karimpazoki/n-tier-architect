using FoodParty.DomainLayer.Contracts;
using System.Reflection;

namespace FoodParty.PresentationLayer.Installers
{
    public static class InstallerExtensions
    {
        private static void InstallServicesFromAssembly(IServiceCollection services, IServiceProvider provider, Assembly assembly, IConfiguration configuration)
        {
            List<IInstaller> installers = assembly.ExportedTypes
              .Where(type => typeof(IInstaller).IsAssignableFrom(type) && type.IsClass && !type.IsAbstract)
              .Select(Activator.CreateInstance).Cast<IInstaller>()
              .ToList();

            installers.ForEach(installer => installer.InstallServices(services, configuration, provider));
        }

        public static void InstallServicesFromCallinfAssembly(this IServiceCollection services, IConfiguration configuration, IServiceProvider provider)
        {
            InstallServicesFromAssembly(services, provider, Assembly.GetCallingAssembly(), configuration);
        }

        public static void InstallServicesInAssemblies(this IServiceCollection services, IServiceProvider provider, IConfiguration configuration, params Assembly[] assemblies)
        {
            foreach (Assembly item in assemblies)
            {
                InstallServicesFromAssembly(services, provider, item, configuration);
            }
        }
    }

    public static class ConfigureMiddlewareExtensions
    {

        public static void UseMiddlewaresFromInAssemblies(this IApplicationBuilder app, IHostEnvironment env, IConfiguration configuration, params Assembly[] assemblies)
        {
            List<IConfigureMiddleware> middlewares = new List<IConfigureMiddleware>();
            foreach (Assembly assembly in assemblies)
            {
                var middlewaresInAssembly = assembly.ExportedTypes
                                                                  .Where(type => typeof(IConfigureMiddleware).IsAssignableFrom(type) && type.IsClass && !type.IsAbstract)
                                                                  .Select(Activator.CreateInstance).Cast<IConfigureMiddleware>()
                                                                  .ToList();

                middlewares.AddRange(middlewaresInAssembly);
            }

            foreach (var middleware in middlewares.OrderBy(middleware => middleware.Order).AsEnumerable())
            {
                middleware.Use(app, env);
            }
        }
    }
}
