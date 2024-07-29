using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace Hotel.FakeData;

public static class ConfigureServices
{
    public static IServiceCollection AddFakeData(this IServiceCollection services)
    {
        services.AddDbContext<AppDbContext>(o => o.UseInMemoryDatabase("HotelDb"), ServiceLifetime.Transient);

        return services;
    }
}
