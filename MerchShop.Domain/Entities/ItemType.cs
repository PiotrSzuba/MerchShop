namespace MerchShop.Domain.Entities;

public class ItemType
{
    public Guid Id { get; private set; }
    public string Name { get; private set; }
    public bool IsInStock { get; private set; }
    public decimal DiscountValue { get; private set; }
    public int Order { get; private set; }

    public Item? Item { get; private set; }

    private ItemType(string name, int order, bool isInStock)
    {
        Name = name;
        IsInStock = isInStock;
        Order = order;
    }

    public static ItemType Create(Item item ,string name, int order, bool isInStock = false)
    {
        return new ItemType(name, order, isInStock)
        {
            Item = item,
        };
    }
}
