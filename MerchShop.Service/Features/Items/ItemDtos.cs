using MerchShop.Domain.Entities;
using MerchShop.Service.Services;
using System.Linq;

namespace MerchShop.Service.Features.Items;

public class ItemDto
{
    public Guid Id { get; set; }
    public string Name { get; set; } = string.Empty;
    public decimal Price { get; set; }
    public string? TypeName { get; set; }
    public string PreviewImage { get; set; } = string.Empty;
    public List<ImageDto> Images { get; set; } = new List<ImageDto>();
    public List<ItemTypeDto> Types { get; set; } = new List<ItemTypeDto>();
    public List<ItemDetailDto> Details { get; set; } = new List<ItemDetailDto>();

    public static class Mapper
    {
        public static ItemDto Map(Item item, IPathProvider pathProvider, IDomainProvider domainProvider)
        {
            return new ItemDto
            {
                Id = item.Id,
                Name = item.Name,
                Price = item.Price,
                TypeName = item.TypeName,
                Images = item.Images.Select(image => ImageDto.Mapper.Map(image, pathProvider, domainProvider)).OrderBy(i => i.File).ToList(),
                Details = item.Details.Select(ItemDetailDto.Mapper.Map).ToList(),
                Types = item.TypeName is null ? new List<ItemTypeDto>() : item.Types.Select(ItemTypeDto.Mapper.Map).OrderBy(t => t.Order).ToList(),
            };
        }
    }
}

public class ItemDetailDto
{
    public Guid Id { get; set; }
    public string? Title { get; set; }
    public DetailType Type { get; set; }
    public List<ItemDetailValueDto> Values { get; set; } = new List<ItemDetailValueDto>();

    public static class Mapper
    {
        public static ItemDetailDto Map(ItemDetail itemDetail)
        {
            return new ItemDetailDto
            {
                Id = itemDetail.Id,
                Title = itemDetail.Title,
                Type = itemDetail.Type,
                Values = itemDetail.Values.Select(ItemDetailValueDto.Mapper.Map).OrderBy(v => v.Order).ToList(),
            };
        }
    }
}

public class ItemDetailValueDto
{
    public Guid Id { get; set; }
    public string Value { get; set; } = string.Empty;
    public int Order { get; set; }

    public static class Mapper
    {
        public static ItemDetailValueDto Map(ItemDetailValue itemDetailValue)
        {
            return new ItemDetailValueDto
            {
                Id = itemDetailValue.Id,
                Value = itemDetailValue.Value,
                Order = itemDetailValue.Order,
            };
        }
    }
}

public class ItemTypeDto
{
    public Guid Id { get; set; }
    public string Name { get; set; } = string.Empty;
    public bool IsInStock { get; set; }
    public decimal DiscountValue { get; set; }
    public int Order { get; set; }

    public static class Mapper
    {
        public static ItemTypeDto Map(ItemType itemType)
        {
            return new ItemTypeDto
            {
                Id = itemType.Id,
                Name = itemType.Name,
                IsInStock= itemType.IsInStock,
                DiscountValue = itemType.DiscountValue,
                Order = itemType.Order,
            };
        }
    }
}

public class ImageDto
{
    public Guid Id { get; set; }
    public string Name { get; set; } = string.Empty;
    public string File { get; set; } = string.Empty;
    public string? ThumbnailFile { get; set; }

    public static class Mapper
    {
        public static ImageDto Map(Image image, IPathProvider pathProvider, IDomainProvider domainProvider)
        {
            return new ImageDto
            {
                Id = image.Id,
                Name = image.Name,
                File = @$"{domainProvider.GetDomainName()}/{pathProvider.GetImagesFolder()}/" + image.File,
                ThumbnailFile = @$"{domainProvider.GetDomainName()}/{pathProvider.GetThumbnailsFolder()}/" + image.ThumbnailFile,
            };
        }
    }
}

