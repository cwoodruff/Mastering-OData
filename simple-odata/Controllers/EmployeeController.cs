using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.OData.Query;
using Microsoft.AspNetCore.OData.Routing.Controllers;
using simple_odata.Data;
using simple_odata.Data.Entities;

namespace simple_odata.Controllers;

public class EmployeeController(ChinookContext db) : ODataController
{
    [EnableQuery]
    [HttpGet("odata/Employees")]
    public ActionResult<IQueryable<Employee>> Get()
    {
        return Ok(db.Employees);
    }
    
    [EnableQuery]
    [HttpGet("odata/Employees({id})")]
    public ActionResult<Employee> Get([FromRoute] int id)
    {
        var employee = db.Employees.SingleOrDefault(d => d.Id == id);

        if (employee == null)
        {
            return NotFound();
        }

        return Ok(employee);
    }
    
    [EnableQuery]
    [HttpPost("odata/Employees")]
    public ActionResult Post([FromBody] Employee employee)
    {
        db.Employees.Add(employee);

        return Created(employee);
    }
    
    [EnableQuery]
    [HttpPut("odata/Employees({id})")]
    public ActionResult Put([FromRoute] int id, [FromBody] Employee updatedEmployee)
    {
        var employee = db.Employees.SingleOrDefault(d => d.Id == id);

        if (employee == null)
        {
            return NotFound();
        }
        
        employee.LastName = updatedEmployee.LastName;
        employee.FirstName = updatedEmployee.FirstName;
        employee.Title = updatedEmployee.Title;
        employee.ReportsTo = updatedEmployee.ReportsTo;
        employee.BirthDate = updatedEmployee.BirthDate;
        employee.HireDate = updatedEmployee.HireDate;
        employee.Address = updatedEmployee.Address;
        employee.City = updatedEmployee.City;
        employee.State = updatedEmployee.State;
        employee.Country = updatedEmployee.Country;
        employee.PostalCode = updatedEmployee.PostalCode;
        employee.Phone = updatedEmployee.Phone;
        employee.Fax = updatedEmployee.Fax;
        employee.Email = updatedEmployee.Email;

        db.SaveChanges();

        return Updated(employee);
    }

    [EnableQuery]
    [HttpDelete("odata/Employees({id})")]
    public ActionResult Delete([FromRoute] int id)
    {
        var employee = db.Employees.SingleOrDefault(d => d.Id == id);

        if (employee != null)
        {
            db.Employees.Remove(employee);
        }

        db.SaveChanges();

        return NoContent();
    }
}