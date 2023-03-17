using MerchShop.Domain.Entities;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;

namespace MerchShop.Persistance.Configuration;

public class MapItemTypes : IEntityTypeConfiguration<ItemType>
{
    public void Configure(EntityTypeBuilder<ItemType> builder)
    {
        builder
            .HasKey(itemType => itemType.Id);

        builder
            .Property(itemType => itemType.Id)
            .HasDefaultValueSql("NEWID()");

        builder
            .HasOne(itemType => itemType.Item)
            .WithMany(item => item.Types)
            .IsRequired();

        builder
            .Property(item => item.DiscountValue)
            .HasPrecision(5, 2);
    }
}
