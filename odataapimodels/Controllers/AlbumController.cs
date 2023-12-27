using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.OData.Query;
using Microsoft.AspNetCore.OData.Routing.Controllers;
using odataapimodels.Domain.ApiModels;
using odataapimodels.Domain.Supervisor;

namespace odataapimodels.Controllers;

public class AlbumController(IChinookSupervisor sup, ILogger<AlbumController> logger) : ODataController
{
    [EnableQuery]
    [HttpGet("odata/Albums")]
    public ActionResult<IQueryable<AlbumApiModel>> Get()
    {
        return Ok(sup.GetAllAlbum());
    }
    
    [EnableQuery]
    [HttpGet("odata/Albums({id})")]
    public ActionResult<AlbumApiModel> Get([FromRoute] int id)
    {
        var album = sup.GetAlbumById(id);

        if (album == null)
        {
            return NotFound();
        }

        return Ok(album);
    }
    
    [EnableQuery]
    [HttpPost("odata/Albums")]
    public ActionResult Post([FromBody] AlbumApiModel album)
    {
        sup.AddAlbum(album);

        return Created(album);
    }
    
    [EnableQuery]
    [HttpPut("odata/Albums{id}")]
    public ActionResult Put([FromRoute] int id, [FromBody] AlbumApiModel updatedAlbum)
    {
        var updated = sup.UpdateAlbum(updatedAlbum);

        if (!updated)
        {
            return NotFound();
        }

        return Updated(updatedAlbum);
    }

    [EnableQuery]
    [HttpDelete("odata/Albums{id}")]
    public ActionResult Delete([FromRoute] int id)
    {
        var deleted = sup.DeleteAlbum(id);

        if (!deleted)
        {
            return NotFound();
        }

        return NoContent();
    }
}