using MerchShop.Domain.Entities;
using MerchShop.Persistance.Configuration;
using Microsoft.EntityFrameworkCore;

namespace MerchShop.Persistance;

public class MerchShopContext : DbContext
{
    public MerchShopContext()
    {

    }

    public MerchShopContext(DbContextOptions<MerchShopContext> options) : base(options)
    {

    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfiguration(new MapItems());
        modelBuilder.ApplyConfiguration(new MapItemDetails());
        modelBuilder.ApplyConfiguration(new MapItemDetailValue());
        modelBuilder.ApplyConfiguration(new MapItemTypes());
        modelBuilder.ApplyConfiguration(new MapImages());
    }

    public DbSet<Item> Items { get; set; }
    public DbSet<ItemDetail> ItemDetailSections { get; set; }
    public DbSet<ItemDetailValue> ItemsValue { get; set; }
    public DbSet<ItemType> ItemTypes { get; set; }
}