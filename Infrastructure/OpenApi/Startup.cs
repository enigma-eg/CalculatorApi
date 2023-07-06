using System.Reflection;

namespace CalculatorApi.Infrastructure.OpenApi
{
    public static class Startup
    {
        internal static IServiceCollection AddOpenApiDocumentation(this IServiceCollection services, IConfiguration config)
        {
            var settings = config.GetSection(nameof(SwaggerSettings)).Get<SwaggerSettings>();
            if (settings.Enable)
            {
                services.ConfigureOptions<ConfigureSwaggerOptions>();

                services.AddVersionedApiExplorer(setup =>
                {
                    setup.GroupNameFormat = "'v'VVV";
                    setup.SubstituteApiVersionInUrl = true;
                });
                services.AddEndpointsApiExplorer();

                if (settings.Enable)
                {
                    services.AddSwaggerGen(options =>
                    {
                        // using System.Reflection;
                        var xmlFilename = $"{Assembly.GetExecutingAssembly().GetName().Name}.xml";
                        options.IncludeXmlComments(Path.Combine(AppContext.BaseDirectory, xmlFilename));
                    });
                }
            }
            return services;
        }
        internal static IApplicationBuilder UseOpenApiDocumentation(this IApplicationBuilder app, IConfiguration config)
        {
            var apiVersionDescriptionProvider = app.ApplicationServices.GetRequiredService<IApiVersionDescriptionProvider>();

            if (config.GetValue<bool>("SwaggerSettings:Enable"))
            {
                app.UseSwagger();
                app.UseSwaggerUI(options =>
                {
                    foreach (var description in apiVersionDescriptionProvider.ApiVersionDescriptions)
                    {
                        options.SwaggerEndpoint($"/swagger/{description.GroupName}/swagger.json",
                            description.GroupName.ToUpperInvariant());
                    }
                });
            }
            return app;
        }
    }
}
