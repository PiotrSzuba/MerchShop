using MerchShop.Domain.Entities;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;

namespace MerchShop.Persistance.Configuration;

public class MapItemDetails : IEntityTypeConfiguration<ItemDetail>
{
    public void Configure(EntityTypeBuilder<ItemDetail> builder)
    {
        builder
            .HasKey(itemDetail => itemDetail.Id);

        builder
            .Property(itemDetail => itemDetail.Id)
            .HasDefaultValueSql("NEWID()");

        builder
            .HasOne(itemDetail => itemDetail.Item)
            .WithMany(item => item.Details)
            .IsRequired();
    }
}
