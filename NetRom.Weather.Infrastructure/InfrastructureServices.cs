using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using NetRom.Weather.Core.Persistance;
using NetRom.Weather.Infrastructure.Persistance;

namespace NetRom.Weather.Infrastructure;

public static class InfrastructureServices
{
    public static IServiceCollection AddInfrastructueServices(this IServiceCollection services, string connectionString)
        => services
            .AddScoped(typeof(IRepository<>), typeof(Repository<>))
            .AddDbContext<ApplicationDbContext>(options => options.UseSqlServer(connectionString));

}
