using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.OData.Query;
using Microsoft.AspNetCore.OData.Routing.Controllers;
using odata_apimodels.Data;
using odata_apimodels.Data.Entities;

namespace odata_apimodels.Controllers;

public class MediaTypeController(ChinookContext db) : ODataController
{
    [EnableQuery]
    [HttpGet("odata/MediaTypes")]
    public ActionResult<IQueryable<MediaType>> Get()
    {
        return Ok(db.MediaTypes);
    }
    
    [EnableQuery]
    [HttpGet("odata/MediaTypes({id})")]
    public ActionResult<MediaType> Get([FromRoute] int id)
    {
        var mediaTypes = db.MediaTypes.SingleOrDefault(d => d.Id == id);

        if (mediaTypes == null)
        {
            return NotFound();
        }

        return Ok(mediaTypes);
    }
    
    [EnableQuery]
    [HttpPost("odata/MediaTypes")]
    public ActionResult Post([FromBody] MediaType mediaTypes)
    {
        db.MediaTypes.Add(mediaTypes);

        return Created(mediaTypes);
    }
    
    [EnableQuery]
    [HttpPut("odata/MediaTypes({id})")]
    public ActionResult Put([FromRoute] int id, [FromBody] MediaType updatedMediaType)
    {
        var mediaTypes = db.MediaTypes.SingleOrDefault(d => d.Id == id);

        if (mediaTypes == null)
        {
            return NotFound();
        }

        mediaTypes.Name = updatedMediaType.Name;

        db.SaveChanges();

        return Updated(mediaTypes);
    }

    [EnableQuery]
    [HttpDelete("odata/MediaTypes({id})")]
    public ActionResult Delete([FromRoute] int id)
    {
        var mediaTypes = db.MediaTypes.SingleOrDefault(d => d.Id == id);

        if (mediaTypes != null)
        {
            db.MediaTypes.Remove(mediaTypes);
        }

        db.SaveChanges();

        return NoContent();
    }
}