namespace MerchShop.Domain.Entities;

public class Item
{
    private List<Image> _images = new();
    private List<ItemType> _types = new();
    private List<ItemDetail> _details = new();

    public Guid Id { get; private set; }
    public string Name { get; private set; }
    public decimal Price { get; private set; }
    public string? TypeName { get; private set; }
    public IReadOnlyCollection<Image> Images => _images.AsReadOnly();
    public IReadOnlyCollection<ItemType> Types => _types.AsReadOnly();
    public IReadOnlyCollection<ItemDetail> Details => _details.AsReadOnly();

    private Item(string name, decimal price, string? typeName = null)
    {
        Name = name;
        Price = price;
        TypeName = typeName;
    }

    public static Item Create(string name, decimal price, string? typeName = null)
    {
        return new Item(name, price, typeName);
    }

    public void AddType(string name, int order, bool isInStock = false)
    {
        _types.Add(ItemType.Create(this, name, order, isInStock));
    }

    public void AddDetail(DetailType detailType, string? title = null)
    {
        _details.Add(ItemDetail.Create(this, detailType, title));
    }

    public void AddDetailWithValues(DetailType detailType, List<string> values, string? title = null)
    {
        var detail = ItemDetail.Create(this, detailType, title);
        for(int i = 0;  i < values.Count; i++)
        {
            detail.AddValue(values[i], i);
        }
        _details.Add(detail);
    }

    public void AddImage(string name, string file, string? thumbnail = null)
    {
        _images.Add(Image.Create(this, name, file, thumbnail));
    }
}
