using RRSS.API.Models;
using RRSS.API.Services;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace RRSS.API.Controllers
{
  [Route("api/[controller]")]
  [ApiController]
  public class SitesController : ControllerBase
  {
    private readonly SitesService _sitesService;

    public SitesController(SitesService sitesService)
    {
      _sitesService = sitesService;
    }

    [HttpGet]
    public ActionResult<List<Site>> Get() =>
        _sitesService.Get();

    [HttpGet("{id:length(24)}", Name = "GetBook")]
    public ActionResult<Site> Get(string id)
    {
      var site = _sitesService.Get(id);

      if (site == null)
      {
        return NotFound();
      }

      return site;
    }

    [HttpPost]
    public ActionResult<Site> Create(Site site)
    {
      _sitesService.Create(site);

      return CreatedAtRoute("GetBook", new { id = site.id.ToString() }, site);
    }

    [HttpPut("{id:length(24)}")]
    public IActionResult Update(string id, Site bookIn)
    {
      var site = _sitesService.Get(id);

      if (site == null)
      {
        return NotFound();
      }

      _sitesService.Update(id, bookIn);

      return NoContent();
    }

    [HttpDelete("{id:length(24)}")]
    public IActionResult Delete(string id)
    {
      var site = _sitesService.Get(id);

      if (site == null)
      {
        return NotFound();
      }

      _sitesService.Remove(site.id);

      return NoContent();
    }
  }
}