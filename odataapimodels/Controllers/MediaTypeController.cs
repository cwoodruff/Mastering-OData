using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.OData.Query;
using Microsoft.AspNetCore.OData.Routing.Controllers;
using odataapimodels.Domain.ApiModels;
using odataapimodels.Domain.Supervisor;

namespace odataapimodels.Controllers;

public class MediaTypeController(IChinookSupervisor sup, ILogger<MediaTypeController> logger) : ODataController
{
    [EnableQuery]
    [HttpGet("odata/MediaTypes")]
    public ActionResult<IQueryable<MediaTypeApiModel>> Get()
    {
        return Ok(sup.GetAllMediaType());
    }
    
    [EnableQuery]
    [HttpGet("odata/MediaTypes({id})")]
    public ActionResult<MediaTypeApiModel> Get([FromRoute] int id)
    {
        var mediaType = sup.GetMediaTypeById(id);

        if (mediaType == null)
        {
            return NotFound();
        }

        return Ok(mediaType);
    }
    
    [EnableQuery]
    [HttpPost("odata/MediaTypes")]
    public ActionResult Post([FromBody] MediaTypeApiModel mediaType)
    {
        sup.AddMediaType(mediaType);

        return Created(mediaType);
    }
    
    [EnableQuery]
    [HttpPut("odata/MediaType{id}")]
    public ActionResult Put([FromRoute] int id, [FromBody] MediaTypeApiModel updatedMediaType)
    {
        var updated = sup.UpdateMediaType(updatedMediaType);

        if (!updated)
        {
            return NotFound();
        }

        return Updated(updatedMediaType);
    }

    [EnableQuery]
    [HttpDelete("odata/MediaType{id}")]
    public ActionResult Delete([FromRoute] int id)
    {
        var deleted = sup.DeleteMediaType(id);

        if (!deleted)
        {
            return NotFound();
        }

        return NoContent();
    }
}