using Microsoft.EntityFrameworkCore;
using NetRom.Weather.Core.Entities;

namespace NetRom.Weather.Infrastructure;

public class ApplicationDbContext : DbContext
{
    public DbSet<City> Cities { get; set; }
    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> dbContextOptions)
        : base(dbContextOptions)
    {
    }
}
