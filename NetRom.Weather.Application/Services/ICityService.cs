using NetRom.Weather.Application.Models;

namespace NetRom.Weather.Application.Services;

public interface ICityService
{
    Task<Guid> CreateAsync(CityModelForCreation cityModelForCreation,CancellationToken cancellationToken = default);
    Task<IEnumerable<CityModel>> GetAllAsync(CancellationToken cancellationToken = default);
    Task<CityModel?> GetByIdAsync(Guid cityId, CancellationToken cancellationToken = default);
    Task<CityModel> UpdateAsync(CityModel cityModel, CancellationToken cancellationToken = default);
    Task DeleteAsync(Guid cityId, CancellationToken cancellationToken = default);
}
