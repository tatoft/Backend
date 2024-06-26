using AlquilaFacilPlatform.Contacts.Domain.Model.Aggregates;
using AlquilaFacilPlatform.Contacts.Domain.Repositories;
using AlquilaFacilPlatform.Shared.Infrastructure.Persistence.EFC.Configuration;
using AlquilaFacilPlatform.Shared.Infrastructure.Persistence.EFC.Repositories;
using Microsoft.EntityFrameworkCore;

namespace AlquilaFacilPlatform.Contacts.Infrastructure.Persistence.EFC.Repositories;

public class ContactRepository(AppDbContext context) : BaseRepository<Contact>(context), IContactRepository
{
    private IContactRepository _contactRepositoryImplementation;

    public Task<Contact?> FindBypropertyIdAsync(int queryPropertyId)
    {
        return context.Set<Contact>().FirstOrDefaultAsync(c => c.propertyId == queryPropertyId);
    }
}