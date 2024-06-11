using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;
using NetRom.Weather.Application.Options;
using NetRom.Weather.Application.Services;
using NetRom.Weather.Infrastructure;

namespace NetRom.Weather.Application;

public static class ApplicationServices
{
    public static IServiceCollection AddApplicationServices(this IServiceCollection services, string connectionString)
    {
        services.AddHttpClient("weather",
            (serviceProvider, client) =>
            {
                var options = serviceProvider.GetRequiredService<IOptions<WeatherApiOptions>>()?.Value;
                client.BaseAddress = new Uri(options.Url);
            });
        services
            .AddScoped<ICityService, CityService>()
            .AddScoped<IWeatherService, WeatherService>();
        services
            .AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies())
            .AddInfrastructueServices(connectionString);


        return services;
    }
}
