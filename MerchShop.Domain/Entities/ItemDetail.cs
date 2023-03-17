using System;

namespace MerchShop.Domain.Entities;

public class ItemDetail
{
    private List<ItemDetailValue> _values = new();

    public Guid Id { get; private set; }
    public string? Title { get; private set; }
    public DetailType Type { get; private set; }
    public Item? Item { get; private set; }
    public IReadOnlyCollection<ItemDetailValue> Values => _values.AsReadOnly();

    private ItemDetail(DetailType type, string? title = null)
    {
        Title = title;
        Type = type;
    }

    public static ItemDetail Create(Item item, DetailType type, string? title = null)
    {
        return new ItemDetail(type, title)
        {
            Item = item,
        };
    } 

    public void AddValue(string value, int order)
    {
        _values.Add(ItemDetailValue.Create(this, value, order));
    }
}

public enum DetailType
{
    List,
    KeyValue,
    TextArea,
}
