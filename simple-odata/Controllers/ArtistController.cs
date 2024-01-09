using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.OData.Formatter;
using Microsoft.AspNetCore.OData.Query;
using Microsoft.AspNetCore.OData.Results;
using Microsoft.AspNetCore.OData.Routing.Controllers;
using simple_odata.Data;
using simple_odata.Data.Entities;

namespace simple_odata.Controllers;

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
    
    // GET /Artists(1)/Albums
    [EnableQuery]
    [HttpGet("odata/Artists({id})/Albums")]
    public IQueryable<Album> GetAlbums([FromODataUri] int id)
    {
        return db.Artists.Where(a => a.Id == id).SelectMany(a => a.Albums);
    }
}