using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.OData.Query;
using Microsoft.AspNetCore.OData.Routing.Controllers;
using odataapimodels.Domain.ApiModels;
using odataapimodels.Domain.Supervisor;

namespace odataapimodels.Controllers;

public class InvoiceController(IChinookSupervisor sup, ILogger<InvoiceController> logger) : ODataController
{
    [EnableQuery]
    [HttpGet("odata/Invoices")]
    public ActionResult<IQueryable<InvoiceApiModel>> Get()
    {
        return Ok(sup.GetAllInvoice());
    }
    
    [EnableQuery]
    [HttpGet("odata/Invoices({id})")]
    public ActionResult<InvoiceApiModel> Get([FromRoute] int id)
    {
        var invoice = sup.GetInvoiceById(id);

        if (invoice == null)
        {
            return NotFound();
        }

        return Ok(invoice);
    }
    
    [EnableQuery]
    [HttpPost("odata/Invoices")]
    public ActionResult Post([FromBody] InvoiceApiModel invoice)
    {
        sup.AddInvoice(invoice);

        return Created(invoice);
    }
    
    [EnableQuery]
    [HttpPut("odata/Invoices{id}")]
    public ActionResult Put([FromRoute] int id, [FromBody] InvoiceApiModel updatedInvoice)
    {
        var updated = sup.UpdateInvoice(updatedInvoice);

        if (!updated)
        {
            return NotFound();
        }

        return Updated(updatedInvoice);
    }

    [EnableQuery]
    [HttpDelete("odata/Invoices{id}")]
    public ActionResult Delete([FromRoute] int id)
    {
        var deleted = sup.DeleteInvoice(id);

        if (!deleted)
        {
            return NotFound();
        }

        return NoContent();
    }
}