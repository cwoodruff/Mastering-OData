using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.OData.Formatter;
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
    
    [EnableQuery]
    [HttpPost("odata/Rate")]
    public IActionResult IncrementBookYear(ODataActionParameters parameters)
    {
        if (!ModelState.IsValid)
        {
            return BadRequest();
        }

        int rating = (int)parameters["Rating"];
        int id = (int)parameters["id"];

        db.Albums.SingleOrDefault((d => d.Id == id));
        
        //this is where you would rate the album

        return Ok();
    }
    
    [EnableQuery]
    [HttpGet("odata/TopTenRatedAlbums")]
    public IActionResult TopTenRatedAlbums()
    {
        //var albums = db.Albums.OrderBy(a => a.Rating).Take(10);
        
        return Ok();
    }
}