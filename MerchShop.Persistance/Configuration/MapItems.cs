using MerchShop.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace MerchShop.Persistance.Configuration;

public class MapItems : IEntityTypeConfiguration<Item>
{
    public void Configure(EntityTypeBuilder<Item> builder)
    {
        builder
            .HasKey(item => item.Id);

        builder
            .Property(item => item.Id)
            .HasDefaultValueSql("NEWID()");

        builder
            .Property(item => item.Name)
            .IsRequired();

        builder
            .Property(item => item.Price)
            .HasPrecision(5, 2);
    }
}
