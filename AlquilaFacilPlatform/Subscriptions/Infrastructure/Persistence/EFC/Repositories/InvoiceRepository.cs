using AlquilaFacilPlatform.Shared.Infrastructure.Persistence.EFC.Configuration;
using AlquilaFacilPlatform.Shared.Infrastructure.Persistence.EFC.Repositories;
using AlquilaFacilPlatform.Subscriptions.Domain.Model.Entities;
using AlquilaFacilPlatform.Subscriptions.Domain.Repositories;
using Microsoft.EntityFrameworkCore;

namespace AlquilaFacilPlatform.Subscriptions.Infrastructure.Persistence.EFC.Repositories;

public class InvoiceRepository(AppDbContext context) : BaseRepository<Invoice>(context), IInvoiceRepository
{
    public new async Task<Invoice?> FindByIdAsync(int id) =>
        await Context.Set<Invoice>().Include(t => t.Subscription)
            .Where(t => t.Id == id).FirstOrDefaultAsync();
    
    public new async Task<IEnumerable<Invoice>> ListAsync()
    {
        return await Context.Set<Invoice>()
            .Include(invoice => invoice.Subscription)
            .ToListAsync();
    }
}