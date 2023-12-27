using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.OData.Query;
using Microsoft.AspNetCore.OData.Routing.Controllers;
using odataapimodels.Domain.ApiModels;
using odataapimodels.Domain.Supervisor;

namespace odataapimodels.Controllers;

public class ArtistController(IChinookSupervisor sup, ILogger<AlbumController> logger) : ODataController
{
    [EnableQuery]
    [HttpGet("odata/Artists")]
    public ActionResult<IQueryable<ArtistApiModel>> Get()
    {
        return Ok(sup.GetAllArtist());
    }
    
    [EnableQuery]
    [HttpGet("odata/Artists({id})")]
    public ActionResult<ArtistApiModel> Get([FromRoute] int id)
    {
        var artist = sup.GetArtistById(id);

        if (artist == null)
        {
            return NotFound();
        }

        return Ok(artist);
    }
    
    [EnableQuery]
    [HttpPost("odata/Artists")]
    public ActionResult Post([FromBody] ArtistApiModel artist)
    {
        sup.AddArtist(artist);

        return Created(artist);
    }
    
    [EnableQuery]
    [HttpPut("odata/Artists({id})")]
    public ActionResult Put([FromRoute] int id, [FromBody] ArtistApiModel updatedArtist)
    {
        var updated = sup.UpdateArtist(updatedArtist);

        if (!updated)
        {
            return NotFound();
        }

        return Updated(updatedArtist);
    }

    [EnableQuery]
    [HttpDelete("odata/Artists({id})")]
    public ActionResult Delete([FromRoute] int id)
    {
        var deleted = sup.DeleteArtist(id);

        if (!deleted)
        {
            return NotFound();
        }

        return NoContent();
    }
}