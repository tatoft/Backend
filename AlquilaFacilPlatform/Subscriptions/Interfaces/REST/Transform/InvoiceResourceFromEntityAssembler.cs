using AlquilaFacilPlatform.Subscriptions.Domain.Model.Entities;
using AlquilaFacilPlatform.Subscriptions.Interfaces.REST.Resources;

namespace AlquilaFacilPlatform.Subscriptions.Interfaces.REST.Transform;

public static class InvoiceResourceFromEntityAssembler
{
    public static InvoiceResource ToResourceFromEntity(Invoice entity)
    {
        return new InvoiceResource(entity.Id, 
            SubscriptionResourceFromEntityAssembler.ToResourceFromEntity(entity.Subscription),
            entity.Amount,
            entity.Date);
    }
}