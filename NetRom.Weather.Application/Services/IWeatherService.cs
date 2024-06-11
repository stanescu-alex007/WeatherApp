using NetRom.Weather.Application.Models;

namespace NetRom.Weather.Application.Services;

public interface IWeatherService
{
    Task<WeatherModel> GetWeatherAsync(double lat, double lon, CancellationToken cancellationToken = default);
}
