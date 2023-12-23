using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.OData.Query;
using Microsoft.AspNetCore.OData.Routing.Controllers;
using simple_odata.Data;
using simple_odata.Data.Entities;

namespace simple_odata.Controllers;

public class CustomerController(ChinookContext db) : ODataController
{
    [EnableQuery]
    [HttpGet("odata/Customers")]
    public ActionResult<IQueryable<Customer>> Get()
    {
        return Ok(db.Customers);
    }
    
    [EnableQuery]
    [HttpGet("odata/Customers({id})")]
    public ActionResult<Customer> Get([FromRoute] int id)
    {
        var customer = db.Customers.SingleOrDefault(d => d.Id == id);

        if (customer == null)
        {
            return NotFound();
        }

        return Ok(customer);
    }
    
    [EnableQuery]
    [HttpPost("odata/Customers")]
    public ActionResult Post([FromBody] Customer customer)
    {
        db.Customers.Add(customer);

        return Created(customer);
    }
    
    [EnableQuery]
    [HttpPut("odata/Customers({id})")]
    public ActionResult Put([FromRoute] int id, [FromBody] Customer updatedCustomer)
    {
        var customer = db.Customers.SingleOrDefault(d => d.Id == id);

        if (customer == null)
        {
            return NotFound();
        }

        customer.FirstName = updatedCustomer.FirstName;
        customer.LastName = updatedCustomer.LastName;
        customer.Company = updatedCustomer.Company;
        customer.Address = updatedCustomer.Address;
        customer.City = updatedCustomer.City;
        customer.State = updatedCustomer.State;
        customer.Country = updatedCustomer.Country;
        customer.PostalCode = updatedCustomer.PostalCode;
        customer.Phone = updatedCustomer.Phone;
        customer.Fax = updatedCustomer.Fax;
        customer.Email = updatedCustomer.Email;

        db.SaveChanges();

        return Updated(customer);
    }

    [EnableQuery]
    [HttpDelete("odata/Customers({id})")]
    public ActionResult Delete([FromRoute] int id)
    {
        var customer = db.Customers.SingleOrDefault(d => d.Id == id);

        if (customer != null)
        {
            db.Customers.Remove(customer);
        }

        db.SaveChanges();

        return NoContent();
    }
}