using Microsoft.Extensions.Options;
using NetRom.Weather.Application.Models;
using NetRom.Weather.Application.Options;
using Newtonsoft.Json;

namespace NetRom.Weather.Application.Services;

public class WeatherService : IWeatherService
{
    private readonly WeatherApiOptions _options;
    private readonly IHttpClientFactory _httpClientFactory;

    public WeatherService(IOptions<WeatherApiOptions> options, IHttpClientFactory httpClientFactory)
    {
        _options = options.Value;
        _httpClientFactory = httpClientFactory;
    }
    public async Task<WeatherModel> GetWeatherAsync(double lat, double lon, CancellationToken cancellationToken = default)
    {
        var client = _httpClientFactory.CreateClient("weather");
        var queyString = $"?lat={lat}&lon={lon}&units=metric&appid={_options.ApiKey}";

        var response = await client.GetAsync(queyString, cancellationToken);

        if (!response.IsSuccessStatusCode)
        {
            //Note: Ce tip de exceptie am putea arunca din acest punct.
        }

        var body = await response.Content.ReadAsStringAsync(cancellationToken);

        if (string.IsNullOrEmpty(body))
        {
            throw new InvalidDataException("Empty response");
        }
        else
        {
            return JsonConvert.DeserializeObject<WeatherModel>(body);
        }
    }
}
