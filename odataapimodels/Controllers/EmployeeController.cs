using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.OData.Query;
using Microsoft.AspNetCore.OData.Routing.Controllers;
using odataapimodels.Domain.ApiModels;
using odataapimodels.Domain.Supervisor;

namespace odataapimodels.Controllers;

public class EmployeeController(IChinookSupervisor sup, ILogger<EmployeeController> logger) : ODataController
{
    [EnableQuery]
    [HttpGet("odata/Employees")]
    public ActionResult<IQueryable<EmployeeApiModel>> Get()
    {
        return Ok(sup.GetAllEmployee());
    }
    
    [EnableQuery]
    [HttpGet("odata/Employees({id})")]
    public ActionResult<EmployeeApiModel> Get([FromRoute] int id)
    {
        var employee = sup.GetEmployeeById(id);

        if (employee == null)
        {
            return NotFound();
        }

        return Ok(employee);
    }
    
    [EnableQuery]
    [HttpPost("odata/Employees")]
    public ActionResult Post([FromBody] EmployeeApiModel employee)
    {
        sup.AddEmployee(employee);

        return Created(employee);
    }
    
    [EnableQuery]
    [HttpPut("odata/Employees{id}")]
    public ActionResult Put([FromRoute] int id, [FromBody] EmployeeApiModel updatedEmployee)
    {
        var updated = sup.UpdateEmployee(updatedEmployee);

        if (!updated)
        {
            return NotFound();
        }

        return Updated(updatedEmployee);
    }

    [EnableQuery]
    [HttpDelete("odata/Employees{id}")]
    public ActionResult Delete([FromRoute] int id)
    {
        var deleted = sup.DeleteEmployee(id);

        if (!deleted)
        {
            return NotFound();
        }

        return NoContent();
    }
}