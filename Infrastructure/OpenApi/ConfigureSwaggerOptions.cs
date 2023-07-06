namespace CalculatorApi.Infrastructure.OpenApi
{
    public class ConfigureSwaggerOptions: IConfigureNamedOptions<SwaggerGenOptions>
    {
        private readonly IApiVersionDescriptionProvider _provider;
        private readonly IConfiguration _config;
        public ConfigureSwaggerOptions(IApiVersionDescriptionProvider provider, IConfiguration config)
        {
            _provider = provider;
            _config = config;
        }
        
        /// <summary>
        /// Configure each API discovered for Swagger Documentation
        /// </summary>
        /// <param name="options"></param>
        public void Configure(SwaggerGenOptions options)
        {
            // add swagger document for every API version discovered
            foreach (var description in _provider.ApiVersionDescriptions)
            {
                options.SwaggerDoc(
                    description.GroupName,
                    CreateVersionInfo(description));
            }
        }

        /// <summary>
        /// Configure Swagger Options. Inherited from the Interface
        /// </summary>
        /// <param name="name"></param>
        /// <param name="options"></param>
        public void Configure(string name, SwaggerGenOptions options)
        {
            Configure(options);
        }

        /// <summary>
        /// Create information about the version of the API
        /// </summary>
        /// <param name="desc"></param>
        /// <returns></returns>
        private OpenApiInfo CreateVersionInfo(ApiVersionDescription desc)
        {
            var settings = _config.GetSection(nameof(SwaggerSettings)).Get<SwaggerSettings>();

            var info = new OpenApiInfo()
            {
                Version = desc.ApiVersion.ToString(),
                Title = settings.Title,
                Description = settings.Description,
                Contact = new OpenApiContact
                {
                    Name = settings.ContactName,
                    Email = settings.ContactEmail
                }
            };
            return info;
        }
    }
}
