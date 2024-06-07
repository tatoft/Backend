using AlquilaFacilPlatform.Shared.Infrastructure.Persistence.EFC.Configuration.Extensions;
using AlquilaFacilPlatform.Subscriptions.Domain.Model.Aggregates;
using AlquilaFacilPlatform.Subscriptions.Domain.Model.Entities;
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
        
        builder.Entity<Plan>().HasKey(p => p.Id);
        builder.Entity<Plan>().Property(p => p.Id).IsRequired().ValueGeneratedOnAdd();
        builder.Entity<Plan>().Property(p => p.Name).IsRequired().HasMaxLength(30);
        builder.Entity<Plan>().Property(p => p.Service).IsRequired().HasMaxLength(30);
        builder.Entity<Plan>().Property(p => p.Price).IsRequired() ;
        
        builder.Entity<Subscription>().HasKey(s => s.Id);
        builder.Entity<Subscription>().Property(s => s.Id).IsRequired().ValueGeneratedOnAdd();
        builder.Entity<Subscription>().Property(s => s.UserId).IsRequired();

        builder.Entity<Invoice>().HasKey(i => i.Id);
        builder.Entity<Invoice>().Property(i => i.Id).IsRequired().ValueGeneratedOnAdd();
        builder.Entity<Invoice>().Property(i => i.SubscriptionId).IsRequired();
        builder.Entity<Invoice>().Property(i => i.Amount).IsRequired();
        builder.Entity<Invoice>().Property(i => i.Date).IsRequired();
        
        builder.Entity<Plan>()
            .HasMany(p => p.Subscriptions)
            .WithOne(s => s.Plan)
            .HasForeignKey(s => s.PlanId)
            .HasPrincipalKey(p => p.Id);
        
        builder.Entity<Subscription>()
            .HasMany(p => p.Invoices)
            .WithOne(i => i.Subscription)
            .HasForeignKey(s => s.SubscriptionId)
            .HasPrincipalKey(s => s.Id);

        //builder.Entity<Subscription>().HasOne(s => s.Plan);
        
        builder.UseSnakeCaseWithPluralizedTableNamingConvention();
    }
}