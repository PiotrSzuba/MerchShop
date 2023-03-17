using SixLabors.ImageSharp;
using SixLabors.ImageSharp.Processing;

namespace MerchShop.Service.Services;

public interface IThumbnailGenerator
{
    Task<Image?> GenerateThumbnailFromUrlAsync(string imageUrl);
    Image? GenerateThumbnail(byte[] bytes);
}

public class ThumbnailGenerator : IThumbnailGenerator
{
    public async Task<Image?> GenerateThumbnailFromUrlAsync(string imageUrl)
    {
        var bytes = await DownloadImageFromUrl(imageUrl);

        return GenerateThumbnail(bytes);
    }

    public Image? GenerateThumbnail(byte[] bytes)
    {
        try
        {
            var image = Image.Load(bytes);

            var scale = image.Height / 256;

            var width = image.Width / scale;
            var height = image.Height / scale;

            image.Mutate(x => x.Resize(width, height, KnownResamplers.Lanczos3));

            return image;
        }
        catch
        {
            return null;
        }
    }

    private async Task<byte[]> DownloadImageFromUrl(string imageUrl)
    {
        using var client = new HttpClient();
        using var response = await client.GetAsync(imageUrl);
        using var stream = await response.Content.ReadAsStreamAsync();
        using var memoryStream = new MemoryStream();
        stream.CopyTo(memoryStream);

        return memoryStream.ToArray();
    }
}
