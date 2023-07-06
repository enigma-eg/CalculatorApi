namespace CalculatorApi.Configurations
{
    public static class Startup
    {
        internal static ConfigureHostBuilder AddConfigurations(this ConfigureHostBuilder host)
        {
            host.ConfigureAppConfiguration((context, config) =>
            {
                const string configurationsDirectory = "Configurations";
                config.AddJsonFile($"{configurationsDirectory}/openapi.json", optional: false, reloadOnChange: true);
            });
            return host;
        }
    }
}
