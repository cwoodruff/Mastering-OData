using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.OData.Query;
using Microsoft.AspNetCore.OData.Routing.Controllers;
using odata_apimodels.Data;
using odata_apimodels.Data.Entities;

namespace odata_apimodels.Controllers;

public class ArtistController(ChinookContext db) : ODataController
{
    [EnableQuery]
    [HttpGet("odata/Artists")]
    public ActionResult<IQueryable<Artist>> Get()
    {
        return Ok(db.Artists);
    }
    
    [EnableQuery]
    [HttpGet("odata/Artists({id})")]
    public ActionResult<Artist> Get([FromRoute] int id)
    {
        var artist = db.Artists.SingleOrDefault(d => d.Id == id);

        if (artist == null)
        {
            return NotFound();
        }

        return Ok(artist);
    }
    
    [EnableQuery]
    [HttpPost("odata/Artists")]
    public ActionResult Post([FromBody] Artist artist)
    {
        db.Artists.Add(artist);

        return Created(artist);
    }
    
    [EnableQuery]
    [HttpPut("odata/Artists({id})")]
    public ActionResult Put([FromRoute] int id, [FromBody] Artist updatedArtist)
    {
        var artist = db.Artists.SingleOrDefault(d => d.Id == id);

        if (artist == null)
        {
            return NotFound();
        }

        artist.Name = updatedArtist.Name;

        db.SaveChanges();

        return Updated(artist);
    }

    [EnableQuery]
    [HttpDelete("odata/Artists({id})")]
    public ActionResult Delete([FromRoute] int id)
    {
        var artist = db.Artists.SingleOrDefault(d => d.Id == id);

        if (artist != null)
        {
            db.Artists.Remove(artist);
        }

        db.SaveChanges();

        return NoContent();
    }
}