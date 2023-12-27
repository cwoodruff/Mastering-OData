using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.OData.Query;
using Microsoft.AspNetCore.OData.Routing.Controllers;
using odataapimodels.Domain.ApiModels;
using odataapimodels.Domain.Supervisor;

namespace odataapimodels.Controllers;

public class TrackController(IChinookSupervisor sup, ILogger<TrackController> logger) : ODataController
{
    [EnableQuery]
    [HttpGet("odata/Tracks")]
    public ActionResult<IQueryable<TrackApiModel>> Get()
    {
        return Ok(sup.GetAllTrack());
    }
    
    [EnableQuery]
    [HttpGet("odata/Tracks({id})")]
    public ActionResult<TrackApiModel> Get([FromRoute] int id)
    {
        var track = sup.GetTrackById(id);

        if (track == null)
        {
            return NotFound();
        }

        return Ok(track);
    }
    
    [EnableQuery]
    [HttpPost("odata/Tracks")]
    public ActionResult Post([FromBody] TrackApiModel track)
    {
        sup.AddTrack(track);

        return Created(track);
    }
    
    [EnableQuery]
    [HttpPut("odata/Tracks{id}")]
    public ActionResult Put([FromRoute] int id, [FromBody] TrackApiModel updatedTrack)
    {
        var updated = sup.UpdateTrack(updatedTrack);

        if (!updated)
        {
            return NotFound();
        }

        return Updated(updatedTrack);
    }

    [EnableQuery]
    [HttpDelete("odata/Tracks{id}")]
    public ActionResult Delete([FromRoute] int id)
    {
        var deleted = sup.DeleteTrack(id);

        if (!deleted)
        {
            return NotFound();
        }

        return NoContent();
    }
}