using Microsoft.Extensions.Configuration;

namespace MerchShop.Service.Services;

public interface IDomainProvider
{
    string GetDomainName();
}

public class DomainProvider : IDomainProvider
{
    private string BaseUrl { get; set; }

    public DomainProvider(IConfiguration configuration)
    {
        var url = configuration.GetSection("ApplicationUrl").Value;

        if (url == null)
            throw new Exception("App url not set !");

        BaseUrl = url;
    }

    public string GetDomainName() => BaseUrl;
}
