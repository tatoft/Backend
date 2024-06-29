using AlquilaFacilPlatform.Contacts.Domain.Model.Aggregates;
using AlquilaFacilPlatform.Contacts.Domain.Model.Commands;
using AlquilaFacilPlatform.Contacts.Domain.Repositories;
using AlquilaFacilPlatform.Contacts.Domain.Services;
using AlquilaFacilPlatform.IAM.Domain.Model.Aggregates;
using AlquilaFacilPlatform.Shared.Domain.Repositories;

namespace AlquilaFacilPlatform.Contacts.Application.Internal.CommandServices;

public class ContactCommandService (IContactRepository contactRepository, IUnitOfWork unitOfWork) : IContactCommandService
{
    public async Task<Contact?> Handle(CreateContactCommand command)
    {
        var userAuthenticated = User.GlobalVariables.UserId;
        var contact = new Contact(command.Name, command.Lastname, command.Message, command.Email, command.Phone, command.propertyId);
        contact.UserId = userAuthenticated;
        await contactRepository.AddAsync(contact);
        await unitOfWork.CompleteAsync();
        return contact;
    }
    
}