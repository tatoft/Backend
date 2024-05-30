using AlquilaFacilPlatform.Locals.Domain.Model.Aggregates;
using AlquilaFacilPlatform.Shared.Infrastructure.Persistence.EFC.Configuration.Extensions;
using EntityFrameworkCore.CreatedUpdatedDate.Extensions;

using Microsoft.EntityFrameworkCore;

namespace AlquilaFacilPlatform.Shared.Infrastructure.Persistence.EFC.Configuration;

public class AppDbContext(DbContextOptions options) : DbContext(options)
{
    protected override void OnConfiguring(DbContextOptionsBuilder builder)
    {
        base.OnConfiguring(builder);
        // Enable Audit Fields Interceptors
        builder.AddCreatedUpdatedInterceptor();
    }

    protected override void OnModelCreating(ModelBuilder builder)
    {
        base.OnModelCreating(builder);
        
        // Place here your entities configuration

        
        
        builder.Entity<Local>().HasKey(p => p.Id);
        builder.Entity<Local>().Property(p => p.Id).IsRequired().ValueGeneratedOnAdd();
        
        builder.Entity<Local>().OwnsOne(p => p.Price,
            n =>
            {
                n.WithOwner().HasForeignKey("Id");
                n.Property(p => p.PriceNight).HasColumnName("PriceNight");
            });

        builder.Entity<Local>().OwnsOne(p => p.LType,
            e =>
            {
                e.WithOwner().HasForeignKey("Id");
                e.Property(a => a.TypeLocal).HasColumnName("TypeLocal");
            });

        builder.Entity<Local>().OwnsOne(p => p.Address,
            a =>
            {
                a.WithOwner().HasForeignKey("Id");
                a.Property(s => s.District).HasColumnName("AddressDistrict");
                a.Property(s => s.Province).HasColumnName("AddressProvince");

            });

        builder.Entity<Local>().OwnsOne(p => p.Photo,
            h =>
            {
                h.WithOwner().HasForeignKey("Id");
                h.Property(g => g.PhotoUrlLink).HasColumnName("AddressDistrict");

            });

        
        // Apply SnakeCase Naming Convention
        builder.UseSnakeCaseWithPluralizedTableNamingConvention();
    }
}