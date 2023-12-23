using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.OData.Query;
using Microsoft.AspNetCore.OData.Routing.Controllers;
using simple_odata.Data;
using simple_odata.Data.Entities;

namespace simple_odata.Controllers;

public class PlaylistController(ChinookContext db) : ODataController
{
    [EnableQuery]
    [HttpGet("odata/Playlists")]
    public ActionResult<IQueryable<Playlist>> Get()
    {
        return Ok(db.Playlists);
    }
    
    [EnableQuery]
    [HttpGet("odata/Playlists({id})")]
    public ActionResult<Playlist> Get([FromRoute] int id)
    {
        var playlist = db.Playlists.SingleOrDefault(d => d.Id == id);

        if (playlist == null)
        {
            return NotFound();
        }

        return Ok(playlist);
    }
    
    [EnableQuery]
    [HttpPost("odata/Playlists")]
    public ActionResult Post([FromBody] Playlist playlist)
    {
        db.Playlists.Add(playlist);

        return Created(playlist);
    }
    
    [EnableQuery]
    [HttpPut("odata/Playlists({id})")]
    public ActionResult Put([FromRoute] int id, [FromBody] Playlist updatedPlaylist)
    {
        var playlist = db.Playlists.SingleOrDefault(d => d.Id == id);

        if (playlist == null)
        {
            return NotFound();
        }

        playlist.Name = updatedPlaylist.Name;

        db.SaveChanges();

        return Updated(playlist);
    }

    [EnableQuery]
    [HttpDelete("odata/Playlists({id})")]
    public ActionResult Delete([FromRoute] int id)
    {
        var playlist = db.Playlists.SingleOrDefault(d => d.Id == id);

        if (playlist != null)
        {
            db.Playlists.Remove(playlist);
        }

        db.SaveChanges();

        return NoContent();
    }
}