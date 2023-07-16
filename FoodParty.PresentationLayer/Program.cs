using FoodParty.PresentationLayer;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;

var host = CreateHostBuilder(args).Build();
host.Run();

static IHostBuilder CreateHostBuilder(string[]? args) =>
    Host.CreateDefaultBuilder(args)
        .ConfigureWebHostDefaults(webBuilder =>
        {
            webBuilder.ConfigureLogging((hostingContext, logging) =>
            {
                logging.ClearProviders();

                logging.AddDebug();

                if (hostingContext.HostingEnvironment.IsDevelopment())
                {
                    logging.AddConsole();
                }

                logging.AddConfiguration(hostingContext.Configuration.GetSection("Logging"));
            })
                .UseStartup<Startup>().ConfigureKestrel(options =>
            {
                options.AllowSynchronousIO = true;
            });
        });