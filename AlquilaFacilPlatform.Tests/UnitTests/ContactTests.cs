using AlquilaFacilPlatform.Contacts.Domain.Model.Aggregates;
using AlquilaFacilPlatform.Contacts.Domain.Model.Commands;

namespace AlquilaFacilPlatform.Tests.UnitTests;

public class ContactTests
{
    [Fact]
    public void Contact_Constructor_WithParameters_ShouldInitializeProperties()
    {
        string name = "John";
        string lastName = "Doe";
        string message = "Me gustaría alquilar esta casa";
        string email = "John_DOE@yahoo.com";
        string phone = "983320616";
        int propertyId = 1;

        var contact = new Contact(name, lastName, message, email, phone, propertyId);
        
        Assert.Equal(email, contact.EAdress.EmailAdress);
        Assert.Equal(message, contact.CMessage.ContactMessage);
        Assert.Equal(name, contact.FullName.Name);
        Assert.Equal(lastName, contact.FullName.Lastname);
        Assert.Equal(phone, contact.NPhone.PhoneNumber);
    }

    [Fact]
    public void Contact_Create_ShouldCreateContacts()
    {
        var createContact = new CreateContactCommand(
            "John",
            "Doe",
            "Me gustaría alquilar esta casa",
            "John_DOE@yahoo.com",
            "983320616",
            1);
        
        var contact = new Contact(createContact);

        Assert.Equal(createContact.Email, contact.EAdress.EmailAdress);
        Assert.Equal(createContact.Message, contact.CMessage.ContactMessage);
        Assert.Equal(createContact.Name, contact.FullName.Name);
        Assert.Equal(createContact.Lastname, contact.FullName.Lastname);
        Assert.Equal(createContact.Phone, contact.NPhone.PhoneNumber);
        
    }
}