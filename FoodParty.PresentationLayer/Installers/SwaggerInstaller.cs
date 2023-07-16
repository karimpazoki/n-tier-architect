using FoodParty.DomainLayer;
using FoodParty.DomainLayer.Contracts;
using FoodParty.Infrastructure.Installers;

namespace FoodParty.PresentationLayer.Installers
{
    public class SwaggerInstaller : IInstaller
    {
        public void InstallServices(IServiceCollection services, IConfiguration configuration, IServiceProvider provider)
        {
            var env = provider.GetRequiredService<IWebHostEnvironment>();

            if (env.IsDevelopment())
            {
                // var settings = configuration.GetRequiredSection("AppSetting").Get<AppSetting>();
                services.AddSwaggerGen();
                //services.AddSwaggerGen(c =>
                //{
                //    //c.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme()
                //    //{
                //    //    Name = "Authorization",
                //    //    Type = SecuritySchemeType.ApiKey,
                //    //    Scheme = "Bearer",
                //    //    BearerFormat = "JWT",
                //    //    In = ParameterLocation.Header,
                //    //    Description = "JWT Authorization header using the Bearer scheme. \r\n\r\n Enter 'Bearer' [space] and then your token in the text input below.\r\n\r\nExample: \"Bearer 1safsfsdfdfd\"",
                //    //});
                //    //c.AddSecurityRequirement(new OpenApiSecurityRequirement
                //    // {
                //    //     {
                //    //           new OpenApiSecurityScheme
                //    //             {
                //    //               Description = "`Token only!!!` - without `Bearer_` prefix",
                //    //                Type = SecuritySchemeType.Http,
                //    //                BearerFormat = "JWT",
                //    //                In = ParameterLocation.Header,
                //    //                Scheme = "bearer",
                //    //                 Reference = new OpenApiReference
                //    //                 {
                //    //                     Type = ReferenceType.SecurityScheme,
                //    //                     Id = "Bearer"
                //    //                 }
                //    //             },
                //    //             new string[] {}
                //    //     }
                //    // });

                //    //c.OperationFilter<AddAuthHeaderOperationFilter>();

                //});
            }
        }
    }
}
