using MediatR;
using MerchShop.Domain.Entities;
using MerchShop.Domain.Exceptions;
using MerchShop.Persistance;
using MerchShop.Service.BuildingBlocks;
using MerchShop.Service.Services;
using Microsoft.IdentityModel.Tokens;
using SixLabors.ImageSharp;

namespace MerchShop.Service.Features.Items.Commands;

public class CreateItemCommand : ICommand
{
    public string Name { get; set; } = string.Empty;
    public decimal Price { get; set; } = 0.0m;
    public string? TypeName { get; set; } = null;
    public List<string> Images { get; set; } = new List<string>();
    public List<ItemType> Types { get; set; } = new List<ItemType>();
    public List<ItemDetailDto> Details { get; set; } = new List<ItemDetailDto>();

    internal class CreateItemCommandHandler : ICommandHandler<CreateItemCommand>
    {
        private readonly MerchShopContext _context;
        private readonly IPathProvider _pathProvider;
        private readonly IThumbnailGenerator _thumbnailGenerator;

        public CreateItemCommandHandler(MerchShopContext context, IPathProvider pathProvider, IThumbnailGenerator thumbnailGenerator)
        {
            _context = context;
            _pathProvider = pathProvider;
            _thumbnailGenerator = thumbnailGenerator;
        }

        public async Task<Unit> Handle(CreateItemCommand request, CancellationToken cancellationToken)
        {
            if (string.IsNullOrWhiteSpace(request.Name))
                throw new EntityInvalidStateException("Name is empty !");

            if (request.Price <= 0.0m)
                throw new EntityInvalidStateException("Price cannot less or equal 0");

            if (request.Images.Count == 0)
                throw new EntityInvalidStateException("Images cannot be empty");

            if (request.Images.Count > 99)
                throw new EntityInvalidStateException("Too many images");

            if (!request.TypeName.IsNullOrEmpty() && request.Types.Count == 0)
                throw new EntityInvalidStateException("Item types cannot be empty");

            var item = Item.Create(request.Name, request.Price, request.TypeName);
            var newItem = _context.Items.Add(item).Entity;

            var addImagesTask = AddImagesAsync(request, newItem, cancellationToken);

            AddItemTypes(request, newItem);
            AddItemDetails(request, newItem);

            await addImagesTask;

            return Unit.Value;
        }
         
        private void AddItemTypes(CreateItemCommand request, Item item)
        {
            if (request.Types.Count == 0 || request.TypeName.IsNullOrEmpty()) return;

            for (int i = 0; i < request.Types.Count; i++)
            {
                item.AddType(request.Types[i].Name, i);
            }
        }

        private void AddItemDetails(CreateItemCommand request, Item item)
        {
            foreach (var detail in request.Details)
            {
                item.AddDetailWithValues(detail.Type, detail.Values.Select(x => x.Value).ToList(), detail.Title);
            }
        }

        private async Task<Unit> AddImagesAsync(CreateItemCommand request, Item item, CancellationToken cancellationToken)
        {
            for(int i = 0; i < request.Images.Count; i++)
            {
                var imageName = $"{item.Name}_{GetOrder(i)}.jpg";
                var imagePath = Path.Combine(_pathProvider.GetImagesPath(), imageName);
                var thumbnailPath = Path.Combine(_pathProvider.GetThumbnailsPath(), imageName);

                var imageData = GetImageData(request.Images[i]);

                var saveImageTask = File.WriteAllBytesAsync(imagePath, imageData, cancellationToken);
                var saveThumbnailTask = GenerateAndSaveThumbnailAsync(thumbnailPath, imageData, cancellationToken);

                await Task.WhenAll(saveImageTask, saveThumbnailTask);
                item.AddImage(imageName, imageName, imageName);
            }

            return Unit.Value;
        }

        private string GetOrder(int order) => order.ToString().PadLeft(2, '0');

        private byte[] GetImageData(string base64)
        {
            int base64Index = base64.IndexOf("base64,");

            try
            {
                return base64Index == -1 ?
                    Convert.FromBase64String(base64) :
                    Convert.FromBase64String(base64.Substring(base64Index + 7));
            }
            catch
            {
                throw new EntityInvalidStateException("Failed to convert image data");
            }

        }

        private async Task<Unit> GenerateAndSaveThumbnailAsync(string path, byte[] data, CancellationToken cancellationToken)
        {
            var thumbnail = _thumbnailGenerator.GenerateThumbnail(data);
            await thumbnail.SaveAsJpegAsync(path, cancellationToken);

            return Unit.Value;
        }
    }
}
