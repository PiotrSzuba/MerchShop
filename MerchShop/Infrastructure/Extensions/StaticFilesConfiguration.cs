using Microsoft.Extensions.FileProviders;

namespace MerchShop.Api.Infrastructure.Extensions;

public static class StaticFilesConfiguration
{
    private const string StaticFiles = "StaticFiles";
    private const string ImagesFolder = "ImagesFolder";
    private const string ThumbnailsFolder = "ThumbnailsFolder";

    public static void ConfigureStaticFiles(this IApplicationBuilder app, WebApplicationBuilder builder)
    {
        var configuration = builder.Configuration;

        app.ConfigureDirectory(builder.Environment.ContentRootPath, GetFolderName(configuration, ImagesFolder));
        app.ConfigureDirectory(builder.Environment.ContentRootPath, GetFolderName(configuration, ThumbnailsFolder));
    }

    private static void ConfigureDirectory(this IApplicationBuilder app, string rootPath, string folderName)
    {
        var directory = Path.Combine(rootPath, folderName);

        if (!Directory.Exists(directory))
        {
            Directory.CreateDirectory(directory);
        }

        var fileProvider = new PhysicalFileProvider(directory);
        var requestPath = $"/{folderName}";

        app.UseStaticFiles(new StaticFileOptions
        {
            FileProvider = fileProvider,
            RequestPath = requestPath
        });

        app.UseDirectoryBrowser(new DirectoryBrowserOptions
        {
            FileProvider = fileProvider,
            RequestPath = requestPath
        });
    }

    private static string GetFolderName(IConfiguration configuration, string sectionName)
    {
        var name = configuration.GetSection(StaticFiles).GetSection(sectionName).Value;

        if (name == null)
            throw new Exception($"{sectionName} folder name not set");

        return name;
    }
}
