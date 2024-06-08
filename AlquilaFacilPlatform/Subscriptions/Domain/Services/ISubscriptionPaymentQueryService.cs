using AlquilaFacilPlatform.Subscriptions.Domain.Model.Entities;
using AlquilaFacilPlatform.Subscriptions.Domain.Model.Queries;

namespace AlquilaFacilPlatform.Subscriptions.Domain.Services;

public interface ISubscriptionPaymentQueryService
{
    Task<SubscriptionPayment?> Handle(GetSubscriptionByIdQuery query);
    Task<IEnumerable<SubscriptionPayment>> Handle(GetAllSubscriptionPayments query);
}