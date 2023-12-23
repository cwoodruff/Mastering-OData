using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.OData.Query;
using Microsoft.AspNetCore.OData.Routing.Controllers;
using simple_odata.Data;
using simple_odata.Data.Entities;

namespace simple_odata.Controllers;

public class TrackController(ChinookContext db) : ODataController
{
    [EnableQuery]
    [HttpGet("odata/Tracks")]
    public ActionResult<IQueryable<Track>> Get()
    {
        return Ok(db.Tracks);
    }
    
    [EnableQuery]
    [HttpGet("odata/Tracks({id})")]
    public ActionResult<Track> Get([FromRoute] int id)
    {
        var track = db.Tracks.SingleOrDefault(d => d.Id == id);

        if (track == null)
        {
            return NotFound();
        }

        return Ok(track);
    }
    
    [EnableQuery]
    [HttpPost("odata/Tracks")]
    public ActionResult Post([FromBody] Track track)
    {
        db.Tracks.Add(track);

        return Created(track);
    }
    
    [EnableQuery]
    [HttpPut("odata/Tracks({id})")]
    public ActionResult Put([FromRoute] int id, [FromBody] Track updatedTrack)
    {
        var track = db.Tracks.SingleOrDefault(d => d.Id == id);

        if (track == null)
        {
            return NotFound();
        }

        track.Name = updatedTrack.Name;
        track.AlbumId = updatedTrack.AlbumId;
        track.MediaTypeId = updatedTrack.MediaTypeId;
        track.GenreId = updatedTrack.GenreId;
        track.Composer = updatedTrack.Composer;
        track.Milliseconds = updatedTrack.Milliseconds;
        track.Bytes = updatedTrack.Bytes;
        track.UnitPrice = updatedTrack.UnitPrice;

        db.SaveChanges();

        return Updated(track);
    }

    [EnableQuery]
    [HttpDelete("odata/Tracks({id})")]
    public ActionResult Delete([FromRoute] int id)
    {
        var track = db.Tracks.SingleOrDefault(d => d.Id == id);

        if (track != null)
        {
            db.Tracks.Remove(track);
        }

        db.SaveChanges();

        return NoContent();
    }
}