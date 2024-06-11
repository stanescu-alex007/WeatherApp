using NetRom.Weather.Core.Persistance;
using NetRom.Weather.Core.Entities;
using Microsoft.EntityFrameworkCore;

namespace NetRom.Weather.Infrastructure.Persistance;

public class Repository<TEntity> : IRepository<TEntity> where TEntity : Entity
{
    protected ApplicationDbContext Context { get; set; }
    private readonly DbSet<TEntity> _entities;
    public Repository(ApplicationDbContext context)
    {
        Context = context;
        _entities = context.Set<TEntity>();
    }
    public async Task<Entity> CreateAsync(TEntity entity, CancellationToken cancellation = default)
    {
        await _entities.AddAsync(entity, cancellation);
        return entity;
    }

    public async Task DeleteAsync(TEntity entity, CancellationToken cancellation = default)
        => await Task.FromResult(_entities.Remove(entity));

    public async Task<IEnumerable<TEntity>> GetAllAsync(CancellationToken cancellation = default)
        => await _entities.ToListAsync(cancellation);

    public async Task<Entity?> GetByIdAsync(Guid id, CancellationToken cancellation = default)
        => await _entities.FindAsync(id, cancellation);

    public async Task UpdateAsync(TEntity entity, CancellationToken cancel = default)
        => await Task.FromResult(_entities.Update(entity));

    public async Task SaveChangesAsync(CancellationToken cancellation = default)
        => await Context.SaveChangesAsync(cancellation);
}
