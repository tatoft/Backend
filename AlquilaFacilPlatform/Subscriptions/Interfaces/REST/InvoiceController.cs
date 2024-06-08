using AlquilaFacilPlatform.Subscriptions.Domain.Model.Queries;
using AlquilaFacilPlatform.Subscriptions.Domain.Services;
using AlquilaFacilPlatform.Subscriptions.Interfaces.REST.Resources;
using AlquilaFacilPlatform.Subscriptions.Interfaces.REST.Transform;
using Microsoft.AspNetCore.Mvc;

namespace AlquilaFacilPlatform.Subscriptions.Interfaces.REST;

[ApiController]
[Route("api/v1/[controller]")]
public class InvoiceController(
    IInvoiceCommandService invoiceCommandService,
    IInvoiceQueryService invoiceQueryService) 
    : ControllerBase
{
    [HttpPost]
    public async Task<IActionResult> CreateInvoice([FromBody] CreateInvoiceResource createInvoiceResource)
    {
        var createInvoiceCommand =
            CreateInvoiceCommandFromResourceAssembler.ToCommandFromResource(createInvoiceResource);
        var invoice = await invoiceCommandService.Handle(createInvoiceCommand);
        if (invoice is null) return BadRequest();
        var resource = InvoiceResourceFromEntityAssembler.ToResourceFromEntity(invoice);
        
        return CreatedAtAction(nameof(GetInvoiceById), new { invoiceId = resource.Id }, resource);
    }
    
    [HttpGet("{invoiceId}")]
    public async Task<IActionResult> GetInvoiceById([FromRoute] int invoiceId)
    {
        var invoice = await invoiceQueryService.Handle(new GetInvoiceByIdQuery(invoiceId));
        if (invoice == null) return NotFound();
        var resource = InvoiceResourceFromEntityAssembler.ToResourceFromEntity(invoice);
        return Ok(resource);
    }
}