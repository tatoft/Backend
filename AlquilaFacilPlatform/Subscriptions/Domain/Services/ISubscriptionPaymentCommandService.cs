using AlquilaFacilPlatform.Subscriptions.Domain.Model.Commands;
using AlquilaFacilPlatform.Subscriptions.Domain.Model.Entities;

namespace AlquilaFacilPlatform.Subscriptions.Domain.Services;

public interface ISubscriptionPaymentCommandService
{
    public Task<SubscriptionPayment?> Handle(CreateSubscriptionPaymentCommand command);
}