using AlquilaFacilPlatform.Shared.Domain.Repositories;
using AlquilaFacilPlatform.Subscriptions.Domain.Model.Commands;
using AlquilaFacilPlatform.Subscriptions.Domain.Model.Entities;
using AlquilaFacilPlatform.Subscriptions.Domain.Repositories;
using AlquilaFacilPlatform.Subscriptions.Domain.Services;

namespace AlquilaFacilPlatform.Subscriptions.Application.Internal.CommandServices;

public class InvoiceCommandService(
    IInvoiceRepository invoiceRepository,
    ISubscriptionRepository subscriptionRepository,
    IUnitOfWork unitOfWork) : IInvoiceCommandService
{
    public async Task<Invoice?> Handle(CreateInvoiceCommand command)
    {
        var invoice = new Invoice(command.SubscriptionId, command.Amount, command.Date);
        await invoiceRepository.AddAsync(invoice);
        await unitOfWork.CompleteAsync();
        var subscription = await subscriptionRepository.FindByIdAsync(command.SubscriptionId);
        invoice.Subscription = subscription;
        return invoice;
    }
}