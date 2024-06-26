using AlquilaFacilPlatform.Contacts.Domain.Model.Aggregates;
using AlquilaFacilPlatform.Shared.Domain.Repositories;

namespace AlquilaFacilPlatform.Contacts.Domain.Repositories;

public interface IContactRepository : IBaseRepository<Contact>
{
    Task<Contact?> FindBypropertyIdAsync(int queryPropertyId);
        Task<Contact?> FindByIdAsync(int id);

}