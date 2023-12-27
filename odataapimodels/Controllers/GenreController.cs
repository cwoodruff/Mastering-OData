using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.OData.Query;
using Microsoft.AspNetCore.OData.Routing.Controllers;
using odataapimodels.Domain.ApiModels;
using odataapimodels.Domain.Supervisor;

namespace odataapimodels.Controllers;

public class GenreController(IChinookSupervisor sup, ILogger<GenreController> logger) : ODataController
{
    [EnableQuery]
    [HttpGet("odata/Genres")]
    public ActionResult<IQueryable<GenreApiModel>> Get()
    {
        return Ok(sup.GetAllGenre());
    }
    
    [EnableQuery]
    [HttpGet("odata/Genres({id})")]
    public ActionResult<GenreApiModel> Get([FromRoute] int id)
    {
        var genre = sup.GetGenreById(id);

        if (genre == null)
        {
            return NotFound();
        }

        return Ok(genre);
    }
    
    [EnableQuery]
    [HttpPost("odata/Genres")]
    public ActionResult Post([FromBody] GenreApiModel genre)
    {
        sup.AddGenre(genre);

        return Created(genre);
    }
    
    [EnableQuery]
    [HttpPut("odata/Genres{id}")]
    public ActionResult Put([FromRoute] int id, [FromBody] GenreApiModel updatedGenre)
    {
        var updated = sup.UpdateGenre(updatedGenre);

        if (!updated)
        {
            return NotFound();
        }

        return Updated(updatedGenre);
    }

    [EnableQuery]
    [HttpDelete("odata/Genres{id}")]
    public ActionResult Delete([FromRoute] int id)
    {
        var deleted = sup.DeleteGenre(id);

        if (!deleted)
        {
            return NotFound();
        }

        return NoContent();
    }
}