using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.OData.Query;
using Microsoft.AspNetCore.OData.Routing.Controllers;
using odataapimodels.Domain.ApiModels;
using odataapimodels.Domain.Supervisor;

namespace odataapimodels.Controllers;

public class PlaylistController(IChinookSupervisor sup, ILogger<PlaylistController> logger) : ODataController
{
    [EnableQuery]
    [HttpGet("odata/Playlists")]
    public ActionResult<IQueryable<PlaylistApiModel>> Get()
    {
        return Ok(sup.GetAllPlaylist());
    }
    
    [EnableQuery]
    [HttpGet("odata/Playlists({id})")]
    public ActionResult<PlaylistApiModel> Get([FromRoute] int id)
    {
        var playlist = sup.GetPlaylistById(id);

        if (playlist == null)
        {
            return NotFound();
        }

        return Ok(playlist);
    }
    
    [EnableQuery]
    [HttpPost("odata/Playlists")]
    public ActionResult Post([FromBody] PlaylistApiModel playlist)
    {
        sup.AddPlaylist(playlist);

        return Created(playlist);
    }
    
    [EnableQuery]
    [HttpPut("odata/Playlists{id}")]
    public ActionResult Put([FromRoute] int id, [FromBody] PlaylistApiModel updatedPlaylist)
    {
        var updated = sup.UpdatePlaylist(updatedPlaylist);

        if (!updated)
        {
            return NotFound();
        }

        return Updated(updatedPlaylist);
    }

    [EnableQuery]
    [HttpDelete("odata/Playlists{id}")]
    public ActionResult Delete([FromRoute] int id)
    {
        var deleted = sup.DeletePlaylist(id);

        if (!deleted)
        {
            return NotFound();
        }

        return NoContent();
    }
}