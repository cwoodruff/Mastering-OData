using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.OData.Query;
using Microsoft.AspNetCore.OData.Routing.Controllers;
using odataapimodels.Domain.ApiModels;
using odataapimodels.Domain.Supervisor;

namespace odataapimodels.Controllers;

public class CustomerController(IChinookSupervisor sup, ILogger<CustomerController> logger) : ODataController
{
    [EnableQuery]
    [HttpGet("odata/Customers")]
    public ActionResult<IQueryable<CustomerApiModel>> Get()
    {
        return Ok(sup.GetAllCustomer());
    }
    
    [EnableQuery]
    [HttpGet("odata/Customers({id})")]
    public ActionResult<CustomerApiModel> Get([FromRoute] int id)
    {
        var customer = sup.GetCustomerById(id);

        if (customer == null)
        {
            return NotFound();
        }

        return Ok(customer);
    }
    
    [EnableQuery]
    [HttpPost("odata/Customers")]
    public ActionResult Post([FromBody] CustomerApiModel customer)
    {
        sup.AddCustomer(customer);

        return Created(customer);
    }
    
    [EnableQuery]
    [HttpPut("odata/Customers{id}")]
    public ActionResult Put([FromRoute] int id, [FromBody] CustomerApiModel updatedCustomer)
    {
        var updated = sup.UpdateCustomer(updatedCustomer);

        if (!updated)
        {
            return NotFound();
        }

        return Updated(updatedCustomer);
    }

    [EnableQuery]
    [HttpDelete("odata/Customers{id}")]
    public ActionResult Delete([FromRoute] int id)
    {
        var deleted = sup.DeleteCustomer(id);

        if (!deleted)
        {
            return NotFound();
        }

        return NoContent();
    }
}