using AutoMapper;
using NetRom.Weather.Application.Models;
using NetRom.Weather.Core.Entities;
using NetRom.Weather.Core.Persistance;
using System.Threading;

namespace NetRom.Weather.Application.Services;

public class CityService : ICityService
{
    
    private readonly IWeatherService _weatherService;
    private readonly IRepository<City> _repository;
    private IMapper _mapper { get; set; }

    public CityService(IMapper mapper, IWeatherService weatherService, IRepository<City> repository)
    {
        _mapper = mapper;
        _weatherService = weatherService;
        _repository = repository;
    }

    public async Task<Guid> CreateAsync(CityModelForCreation cityModelForCreation, CancellationToken cancellationToken = default)
    {
        var result = await _repository.CreateAsync(_mapper.Map<City>(cityModelForCreation), cancellationToken);
        await _repository.SaveChangesAsync(cancellationToken);

        return result.Id;
    }

    public async Task DeleteAsync(Guid cityId, CancellationToken cancellationToken = default)
    {
        await _repository.DeleteAsync(new City { Id = cityId }, cancellationToken);
        await _repository.SaveChangesAsync(cancellationToken);
    }

    public async Task<IEnumerable<CityModel>> GetAllAsync(CancellationToken cancellationToken = default)
    {
        var cities = await _repository.GetAllAsync(cancellationToken);
        var cityModels = _mapper.Map<IEnumerable<CityModel>>(cities);

        foreach (var city in cityModels)
        {
            var cityWeather = await _weatherService.GetWeatherAsync(city.Latitude, city.Longitude);
            city.Temperature = cityWeather.Main?.Temp;
        }
        return cityModels;
    }

    public async Task<CityModel?> GetByIdAsync(Guid cityId, CancellationToken cancellationToken = default)
    {
        var city = await _repository.GetByIdAsync(cityId, cancellationToken);
        var cityModel = _mapper.Map<CityModel>(city);
        return cityModel;
    }

    public async Task<CityModel> UpdateAsync(CityModel cityModel, CancellationToken cancellationToken = default)
    {
        var city = _mapper.Map<City>(cityModel);

        await _repository.UpdateAsync(city, cancellationToken);

        await _repository.SaveChangesAsync(cancellationToken);

        return cityModel;
    }
}
