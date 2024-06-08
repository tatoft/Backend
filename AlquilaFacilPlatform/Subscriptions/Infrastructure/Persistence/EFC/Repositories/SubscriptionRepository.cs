using AlquilaFacilPlatform.Shared.Infrastructure.Persistence.EFC.Configuration;
using AlquilaFacilPlatform.Shared.Infrastructure.Persistence.EFC.Repositories;
using AlquilaFacilPlatform.Subscriptions.Domain.Model.Aggregates;
using AlquilaFacilPlatform.Subscriptions.Domain.Repositories;
using Microsoft.EntityFrameworkCore;

namespace AlquilaFacilPlatform.Subscriptions.Infrastructure.Persistence.EFC.Repositories;

public class SubscriptionRepository(AppDbContext context)
    : BaseRepository<Subscription>(context), ISubscriptionRepository
{
    public new async Task<Subscription?> FindByIdAsync(int id) =>
        await Context.Set<Subscription>().Include(t => t.Plan)
            .Where(t => t.Id == id).FirstOrDefaultAsync();
    
    public new async Task<IEnumerable<Subscription>> ListAsync()
    {
        return await Context.Set<Subscription>()
            .Include(subscription => subscription.Plan)
            .ToListAsync();
    }

    public async Task<IEnumerable<Subscription>> FindByCategoryIdAsync(int planId)
    {
        return await Context.Set<Subscription>()
            .Include(subscription => subscription.Plan)
            .Where(subscription => subscription.PlanId == planId)
            .ToListAsync();
    }
}