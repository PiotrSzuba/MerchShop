using MerchShop.Domain.Entities;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;

namespace MerchShop.Persistance.Configuration;

internal class MapItemDetailValue : IEntityTypeConfiguration<ItemDetailValue>
{
    public void Configure(EntityTypeBuilder<ItemDetailValue> builder)
    {
        builder
            .HasKey(iitemDetailValue => iitemDetailValue.Id);

        builder
            .Property(iitemDetailValue => iitemDetailValue.Id)
            .HasDefaultValueSql("NEWID()");

        builder
            .HasOne(iitemDetailValue => iitemDetailValue.ItemDetail)
            .WithMany(itemDetail => itemDetail.Values)
            .IsRequired();
    }
}
