using MerchShop.Domain.Entities;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;

namespace MerchShop.Persistance.Configuration;

public class MapImages : IEntityTypeConfiguration<Image>
{
    public void Configure(EntityTypeBuilder<Image> builder)
    {
        builder
            .HasKey(image => image.Id);

        builder
            .Property(image => image.Id)
            .HasDefaultValueSql("NEWID()");

        builder
            .Property(image => image.File)
            .IsRequired();

        builder
            .Property(image => image.ThumbnailFile)
            .IsRequired(false);

        builder
            .HasOne(image => image.Item)
            .WithMany(item => item.Images)
            .IsRequired(false);
    }
}
