namespace MerchShop.Api.Infrastructure.Extensions;

public static class CorsConfiguration
{
    public static void AddCorsPolicy(this WebApplication app, IConfiguration configuration)
    {
        var url = configuration.GetSection("FrontendAppUrl").Value;

        if (url == null)
            throw new Exception("WebApp url not set !");

        app.UseCors(builder => builder
            .AllowAnyMethod()
            .AllowAnyHeader()
            .SetIsOriginAllowed(origin => true)
            .WithOrigins(url)
            .AllowCredentials());
    }
}
