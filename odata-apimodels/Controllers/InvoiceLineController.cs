using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.OData.Query;
using Microsoft.AspNetCore.OData.Routing.Controllers;
using odata_apimodels.Data;
using odata_apimodels.Data.Entities;

namespace odata_apimodels.Controllers;

public class InvoiceLineController(ChinookContext db) : ODataController
{
    [EnableQuery]
    [HttpGet("odata/InvoiceLines")]
    public ActionResult<IQueryable<InvoiceLine>> Get()
    {
        return Ok(db.InvoiceLines);
    }
    
    [EnableQuery]
    [HttpGet("odata/InvoiceLines({id})")]
    public ActionResult<InvoiceLine> Get([FromRoute] int id)
    {
        var invoiceLine = db.InvoiceLines.SingleOrDefault(d => d.Id == id);

        if (invoiceLine == null)
        {
            return NotFound();
        }

        return Ok(invoiceLine);
    }
    
    [EnableQuery]
    [HttpPost("odata/InvoiceLines")]
    public ActionResult Post([FromBody] InvoiceLine invoiceLine)
    {
        db.InvoiceLines.Add(invoiceLine);

        return Created(invoiceLine);
    }
    
    [EnableQuery]
    [HttpPut("odata/InvoiceLines({id})")]
    public ActionResult Put([FromRoute] int id, [FromBody] InvoiceLine updatedInvoiceLine)
    {
        var invoiceLine = db.InvoiceLines.SingleOrDefault(d => d.Id == id);

        if (invoiceLine == null)
        {
            return NotFound();
        }

        invoiceLine.InvoiceId = updatedInvoiceLine.InvoiceId;
        invoiceLine.TrackId = updatedInvoiceLine.TrackId;
        invoiceLine.UnitPrice = updatedInvoiceLine.UnitPrice;
        invoiceLine.Quantity = updatedInvoiceLine.Quantity;
        
        db.SaveChanges();

        return Updated(invoiceLine);
    }

    [EnableQuery]
    [HttpDelete("odata/InvoiceLines({id})")]
    public ActionResult Delete([FromRoute] int id)
    {
        var invoiceLine = db.InvoiceLines.SingleOrDefault(d => d.Id == id);

        if (invoiceLine != null)
        {
            db.InvoiceLines.Remove(invoiceLine);
        }

        db.SaveChanges();

        return NoContent();
    }
}