using System;
using Microsoft.AspNetCore.Mvc;
using RESTAPIProject.Models.VillaDTO;
using RESTAPIProject.Data.VillaStore;

namespace RESTAPIProject.Controllers.VillaController
{   
    [Route("api/[controller]")]
    [ApiController]
    public class VillaApiController : ControllerBase
    {
        [HttpGet]
        [ProducesResponseType(200)]
        public ActionResult<IEnumerable<VillaDTO>> GetVillas()
        {
            return Ok(VillaStore.villaList);
        }

        [HttpGet("ByIDorName")]
        [ProducesResponseType(200)]
        [ProducesResponseType(400)]
        [ProducesResponseType(404)]
        public IActionResult GetVilla([FromQuery] int? id, [FromQuery] string? name)
        {
            if (id.HasValue)
            {
                var villaId = VillaStore.villaList.FirstOrDefault(x => x.Id == id.Value);
                if (villaId == null)
                {
                    return NotFound();
                }
                return Ok(villaId);
            }
            else if (!string.IsNullOrEmpty(name))
            {
                var villaName = VillaStore.villaList.Where(x => x.Name.Equals(name, StringComparison.OrdinalIgnoreCase)).ToList();
                if (villaName.Count == 0)
                {
                    return NotFound();
                }
                return Ok(villaName);
            }
            else
            {
                return BadRequest("Must enter valid Id or Name");
            }
        }

        [HttpPost]
        [ProducesResponseType(200)]
        [ProducesResponseType(400)]
        [ProducesResponseType(409)]
        public ActionResult<VillaDTO> CreateVilla(string name)
        {
            if (string.IsNullOrEmpty(name))
            {
                return BadRequest();
            }
            if (VillaStore.villaList.Any(x => x.Name.Equals(name, StringComparison.OrdinalIgnoreCase)))
            {
                return Conflict(new { message = "This name already exists in the database" });
            }
                        
            int villaId = VillaStore.villaList.Any() ? VillaStore.villaList.Max(x => x.Id) : 1;
            var newVilla = new VillaDTO { Id=villaId, Name=name };
            VillaStore.villaList.Add(newVilla);
            return Ok(newVilla);        
        }
    }
}