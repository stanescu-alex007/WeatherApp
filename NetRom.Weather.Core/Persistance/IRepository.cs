using NetRom.Weather.Core.Entities;

namespace NetRom.Weather.Core.Persistance;

public interface IRepository<TEntity> where TEntity : Entity
{
    Task<Entity> CreateAsync(TEntity entity, CancellationToken cancellation = default);
    Task<Entity?> GetByIdAsync(Guid id, CancellationToken cancellation = default);
    Task<IEnumerable<TEntity>> GetAllAsync(CancellationToken cancellation = default);
    Task DeleteAsync(TEntity entity, CancellationToken cancellation = default);
    Task UpdateAsync(TEntity entity, CancellationToken cancel = default);
    Task SaveChangesAsync(CancellationToken cancellation = default);
}
