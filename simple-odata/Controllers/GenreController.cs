using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.OData.Query;
using Microsoft.AspNetCore.OData.Routing.Controllers;
using simple_odata.Data;
using simple_odata.Data.Entities;

namespace simple_odata.Controllers;

public class GenreController(ChinookContext db) : ODataController
{
    [EnableQuery]
    [HttpGet("odata/Genres")]
    public ActionResult<IQueryable<Genre>> Get()
    {
        return Ok(db.Genres);
    }
    
    [EnableQuery]
    [HttpGet("odata/Genres({id})")]
    public ActionResult<Genre> Get([FromRoute] int id)
    {
        var genre = db.Genres.SingleOrDefault(d => d.Id == id);

        if (genre == null)
        {
            return NotFound();
        }

        return Ok(genre);
    }
    
    [EnableQuery]
    [HttpPost("odata/Genres")]
    public ActionResult Post([FromBody] Genre genre)
    {
        db.Genres.Add(genre);

        return Created(genre);
    }
    
    [EnableQuery]
    [HttpPut("odata/Genres({id})")]
    public ActionResult Put([FromRoute] int id, [FromBody] Genre updatedGenre)
    {
        var genre = db.Genres.SingleOrDefault(d => d.Id == id);

        if (genre == null)
        {
            return NotFound();
        }

        genre.Name = updatedGenre.Name;

        db.SaveChanges();

        return Updated(genre);
    }

    [EnableQuery]
    [HttpDelete("odata/Genres({id})")]
    public ActionResult Delete([FromRoute] int id)
    {
        var genre = db.Genres.SingleOrDefault(d => d.Id == id);

        if (genre != null)
        {
            db.Genres.Remove(genre);
        }

        db.SaveChanges();

        return NoContent();
    }
}