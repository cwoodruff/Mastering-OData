using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.OData.Query;
using Microsoft.AspNetCore.OData.Routing.Controllers;
using odata_apimodels.Data;
using odata_apimodels.Data.Entities;

namespace odata_apimodels.Controllers;

public class InvoiceController(ChinookContext db) : ODataController
{
    [EnableQuery]
    [HttpGet("odata/Invoices")]
    public ActionResult<IQueryable<Invoice>> Get()
    {
        return Ok(db.Invoices);
    }
    
    [EnableQuery]
    [HttpGet("odata/Invoices({id})")]
    public ActionResult<Invoice> Get([FromRoute] int id)
    {
        var invoice = db.Invoices.SingleOrDefault(d => d.Id == id);

        if (invoice == null)
        {
            return NotFound();
        }

        return Ok(invoice);
    }
    
    [EnableQuery]
    [HttpPost("odata/Invoices")]
    public ActionResult Post([FromBody] Invoice invoice)
    {
        db.Invoices.Add(invoice);

        return Created(invoice);
    }
    
    [EnableQuery]
    [HttpPut("odata/Invoices({id})")]
    public ActionResult Put([FromRoute] int id, [FromBody] Invoice updatedInvoice)
    {
        var invoice = db.Invoices.SingleOrDefault(d => d.Id == id);

        if (invoice == null)
        {
            return NotFound();
        }

        invoice.CustomerId = updatedInvoice.CustomerId;
        invoice.InvoiceDate = updatedInvoice.InvoiceDate;
        invoice.BillingAddress = updatedInvoice.BillingAddress;
        invoice.BillingCity = updatedInvoice.BillingCity;
        invoice.BillingState = updatedInvoice.BillingState;
        invoice.BillingCountry = updatedInvoice.BillingCountry;
        invoice.BillingPostalCode = updatedInvoice.BillingPostalCode;
        invoice.Total = updatedInvoice.Total;
        
        db.SaveChanges();

        return Updated(invoice);
    }

    [EnableQuery]
    [HttpDelete("odata/Invoices({id})")]
    public ActionResult Delete([FromRoute] int id)
    {
        var invoice = db.Invoices.SingleOrDefault(d => d.Id == id);

        if (invoice != null)
        {
            db.Invoices.Remove(invoice);
        }

        db.SaveChanges();

        return NoContent();
    }
}