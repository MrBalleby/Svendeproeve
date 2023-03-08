using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace CanteenSystemsApi.Areas.Identity.Data;

public class CanteenSystemsApiContext : IdentityDbContext<IdentityUser>
{
    public CanteenSystemsApiContext(DbContextOptions<CanteenSystemsApiContext> options)
        : base(options)
    {
    }
    public DbSet<Model.Auth> Auths { get; set; }
    public DbSet<Model.Item> Items { get; set; }
    public DbSet<Model.Catering> Caterings { get; set; }
    public DbSet<Model.CateringCategory> CateringsCategory { get; set;}
    public DbSet<Model.ItemGroup> ItemsGroup { get; set; }
    public DbSet<Model.Order> Orders { get; set; }
    public DbSet<Model.BuffetRegistration> BuffetRegistrations { get; set; }
    public DbSet<Model.BuffetMenu> BuffetMenu { get; set; }

    protected override void OnModelCreating(ModelBuilder builder)
    {
        base.OnModelCreating(builder);
        builder.Entity<Model.Auth>().ToTable("Auth");
        builder.Entity<Model.Item>().ToTable("Item");
        builder.Entity<Model.Catering>().ToTable("Catering");
        builder.Entity<Model.CateringCategory>().ToTable("CateringCategory");
        builder.Entity<Model.ItemGroup>().ToTable("ItemGroup");
        builder.Entity<Model.Order>().ToTable("Order");
        builder.Entity<Model.BuffetRegistration>().ToTable("BuffetRegistration");
        builder.Entity<Model.BuffetMenu>().ToTable("BuffetMenu");
    }

}
