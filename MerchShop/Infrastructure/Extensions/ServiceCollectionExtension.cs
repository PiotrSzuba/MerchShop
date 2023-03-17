using MerchShop.Persistance;
using Microsoft.EntityFrameworkCore;

namespace MerchShop.Api.Infrastructure.Extensions;

public static class ServiceCollectionExtension
{
    public static void AddDatabase(this IServiceCollection services, IConfiguration configuration)
    {
       services.AddDbContext<MerchShopContext>(options =>
            options.UseSqlServer(configuration.GetConnectionString("MerchShopContext")));
    }
}
