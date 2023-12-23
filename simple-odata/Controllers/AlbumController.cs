using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.OData.Query;
using Microsoft.AspNetCore.OData.Routing.Controllers;
using simple_odata.Data;
using simple_odata.Data.Entities;

namespace simple_odata.Controllers;

public class AlbumController(ChinookContext db) : ODataController
{
    [EnableQuery]
    [HttpGet("odata/Albums")]
    public ActionResult<IQueryable<Album>> Get()
    {
        return Ok(db.Albums);
    }
    
    [EnableQuery]
    [HttpGet("odata/Albums({id})")]
    public ActionResult<Album> Get([FromRoute] int id)
    {
        var album = db.Albums.SingleOrDefault(d => d.Id == id);

        if (album == null)
        {
            return NotFound();
        }

        return Ok(album);
    }
    
    [EnableQuery]
    [HttpPost("odata/Albums")]
    public ActionResult Post([FromBody] Album album)
    {
        db.Albums.Add(album);

        return Created(album);
    }
    
    [EnableQuery]
    [HttpPut("{id}")]
    public ActionResult Put([FromRoute] int id, [FromBody] Album updatedAlbum)
    {
        var album = db.Albums.SingleOrDefault(d => d.Id == id);

        if (album == null)
        {
            return NotFound();
        }

        album.Title = updatedAlbum.Title;
        album.ArtistId = updatedAlbum.ArtistId;

        db.SaveChanges();

        return Updated(album);
    }

    [EnableQuery]
    [HttpDelete("{id}")]
    public ActionResult Delete([FromRoute] int id)
    {
        var album = db.Albums.SingleOrDefault(d => d.Id == id);

        if (album != null)
        {
            db.Albums.Remove(album);
        }

        db.SaveChanges();

        return NoContent();
    }
}