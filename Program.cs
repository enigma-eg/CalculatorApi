namespace CalculatorApi
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            builder.Host.AddConfigurations();


            // Add services to the container.

            builder.Services.AddControllers();

            builder.Services.AddRouting(options => options.LowercaseUrls = true);

            builder.Services.AddApiVersioning(opt =>
            {
                opt.DefaultApiVersion = new ApiVersion(1, 0);
                opt.AssumeDefaultVersionWhenUnspecified = true;
                opt.ReportApiVersions = true;
                opt.ApiVersionReader = ApiVersionReader.Combine(new UrlSegmentApiVersionReader(),
                                                                new HeaderApiVersionReader("x-api-version"),
                                                                new MediaTypeApiVersionReader("x-api-version"));
            });

            builder.Services.AddOpenApiDocumentation(builder.Configuration);

            // Add ApiExplorer to discover versions
        
            var app = builder.Build();

            // Configure the HTTP request pipeline.

            app.UseOpenApiDocumentation(builder.Configuration);

            app.UseHttpsRedirection();

            app.UseAuthorization();

            app.MapControllers();

            app.Run();
        }
    }
}