namespace MerchShop.Domain.Entities;

public class ItemDetailValue
{
    public Guid Id { get; private set; }
    public string Value { get; private set; }
    public int Order { get; private set; }
    public ItemDetail? ItemDetail { get; private set; }

    private ItemDetailValue(string value, int order)
    {
        Value = value;
        Order = order;
    }

    public static ItemDetailValue Create(ItemDetail itemDetail, string value, int order)
    {
        return new ItemDetailValue(value, order)
        {
            ItemDetail = itemDetail,
        };
    }
}
