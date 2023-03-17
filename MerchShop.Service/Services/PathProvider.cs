using Microsoft.Extensions.Configuration;

namespace MerchShop.Service.Services;

public interface IPathProvider
{
    string GetRoot();
    string GetThumbnailsPath();
    string GetImagesPath();
    string GetThumbnailsFolder();
    string GetImagesFolder();
}

public class PathProvider : IPathProvider
{
    private static string ThumbnailsFolder { get; set; } = string.Empty;
    private static string ImagesFolder { get; set; } = string.Empty;
    private string Root { get; set; }
    private string ThumbnailsPath { get; set; }
    private string ImagesPath { get; set; }

    public PathProvider(string root, IConfiguration configuration)
    {
        Root = root;

        var staticFileSection = configuration.GetSection("StaticFiles");

        if (staticFileSection == null)
            throw new Exception("StaticFile section not set !");

        var thumbnailFolder = staticFileSection.GetSection("ThumbnailsFolder").Value;

        if (thumbnailFolder == null)
            throw new Exception("Thumbanails folder name not set !");

        var imagesFolder = staticFileSection.GetSection("ImagesFolder").Value;

        if (imagesFolder == null)
            throw new Exception("Images folder name not set !");

        ThumbnailsFolder = thumbnailFolder;
        ImagesFolder = imagesFolder;

        ThumbnailsPath = Path.Combine(root, ThumbnailsFolder);
        ImagesPath = Path.Combine(root, ImagesFolder);
    }

    public string GetRoot() => Root;
    public string GetThumbnailsPath() => ThumbnailsPath;
    public string GetImagesPath() => ImagesPath;
    public string GetThumbnailsFolder() => ThumbnailsFolder;
    public string GetImagesFolder() => ImagesFolder;
}
