using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.OData.Query;
using Microsoft.AspNetCore.OData.Routing.Controllers;
using odataapimodels.Domain.ApiModels;
using odataapimodels.Domain.Supervisor;

namespace odataapimodels.Controllers;

public class InvoiceLineController(IChinookSupervisor sup, ILogger<InvoiceLineController> logger) : ODataController
{
    [EnableQuery]
    [HttpGet("odata/InvoiceLines")]
    public ActionResult<IQueryable<InvoiceLineApiModel>> Get()
    {
        return Ok(sup.GetAllInvoiceLine());
    }
    
    [EnableQuery]
    [HttpGet("odata/InvoiceLines({id})")]
    public ActionResult<InvoiceLineApiModel> Get([FromRoute] int id)
    {
        var invoiceLine = sup.GetInvoiceLineById(id);

        if (invoiceLine == null)
        {
            return NotFound();
        }

        return Ok(invoiceLine);
    }
    
    [EnableQuery]
    [HttpPost("odata/InvoiceLines")]
    public ActionResult Post([FromBody] InvoiceLineApiModel invoiceLine)
    {
        sup.AddInvoiceLine(invoiceLine);

        return Created(invoiceLine);
    }
    
    [EnableQuery]
    [HttpPut("odata/InvoiceLines{id}")]
    public ActionResult Put([FromRoute] int id, [FromBody] InvoiceLineApiModel updatedInvoiceLine)
    {
        var updated = sup.UpdateInvoiceLine(updatedInvoiceLine);

        if (!updated)
        {
            return NotFound();
        }

        return Updated(updatedInvoiceLine);
    }

    [EnableQuery]
    [HttpDelete("odata/InvoiceLines{id}")]
    public ActionResult Delete([FromRoute] int id)
    {
        var deleted = sup.DeleteInvoiceLine(id);

        if (!deleted)
        {
            return NotFound();
        }

        return NoContent();
    }
}