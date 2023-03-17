namespace MerchShop.Domain.Entities;

public class Image
{
    public Guid Id { get; private set; }
    public string Name { get; private set; }
    public string File { get; private set; }
    public string? ThumbnailFile { get; private set; }

    public Item? Item { get; private set; }
    

    private Image(string name, string file, string? thumbnailFile = null)
    {
        Name = name;
        File = file;
        ThumbnailFile = thumbnailFile;
    }

    public static Image Create(Item item, string name, string file, string? thumbnailFile = null )
    {
        return new Image(name, file, thumbnailFile)
        {
            Item = item,
        };
    }
}
