using System;
using Microsoft.AspNetCore.Mvc;
using RESTAPIProject.Models.VillaDTO;
using RESTAPIProject.Data.VillaStore;
using RESTAPIProject.Validation.ValidationAttributes;
using System.Linq;
using RESTAPIProject.Models.CreateVillaDTO;
using Microsoft.AspNetCore.JsonPatch;


namespace RESTAPIProject.Controllers.VillaController
{   
    [Route("api/[controller]")]
    [ApiController]
    public class VillaApiController : ControllerBase
    {
        private readonly ILogger<VillaApiController> _logger;
        public VillaApiController(ILogger<VillaApiController> logger)
        {
            _logger = logger;
        } 

        [HttpGet]
        [ProducesResponseType(200)]
        public ActionResult<IEnumerable<VillaDTO>> GetVillas()
        {
            _logger.LogInformation("Getting All Villas");
            return Ok(VillaStore.villaList);
        }

        [HttpGet("ByIDorName", Name = "Get Villa")]
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

        [HttpPost(Name = "Create Villa")]
        [ProducesResponseType(201)]
        [ProducesResponseType(400)]
        [ProducesResponseType(409)]
        public ActionResult<VillaDTO> CreateVilla([FromBody] CreateVillaRequest request)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            if (VillaStore.villaList.Any(x => x.Name.Equals(request.Name, StringComparison.OrdinalIgnoreCase)))
            {
                return Conflict(new { message = "This name already exists in the database" });
            }
                        
            int villaId = VillaStore.villaList.Any() ? VillaStore.villaList.Max(x => x.Id) + 1 : 1;
            var newVilla = new VillaDTO { Id=villaId, Name=request.Name };
            VillaStore.villaList.Add(newVilla);
            return CreatedAtRoute("Get Villa", new { id = newVilla.Id, name = newVilla.Name }, newVilla);        
        }

        [HttpDelete("{id}", Name = "Delete Villa")]
        [ProducesResponseType(404)]
        [ProducesResponseType(204)]
        public IActionResult DeleteVilla(int id)
        {
            if (!VillaStore.villaList.Any(x => x.Id == id))
            {
                return NotFound();
            }

            VillaStore.villaList.RemoveAll(x => x.Id == id);
            return NoContent();
        }

        [HttpPut("{id}", Name = "Update Villa")]
        [ProducesResponseType(400)]
        [ProducesResponseType(204)]
        public IActionResult UpdateVilla(int id, [FromBody] CreateVillaRequest request)
        {
            var villaId = VillaStore.villaList.FirstOrDefault(x => x.Id == id);
            if (villaId == null)
            {
                return BadRequest($"ID: {id} not found");
            }

            villaId.Name = request.Name;
            villaId.Occupancy = request.Occupancy;
            return NoContent();
        }

        [HttpPatch("{id}", Name = "Patch Villa")]
        [ProducesResponseType(404)]
        [ProducesResponseType(400)]
        [ProducesResponseType(204)]
        public IActionResult PatchVilla(int id, [FromBody] JsonPatchDocument<CreateVillaRequest> patch)
        {
            var villaId = VillaStore.villaList.FirstOrDefault(x => x.Id == id);
            if (villaId == null)
            {
                return NotFound($"ID: {id} not found");
            }

            var patchVilla = new CreateVillaRequest {
                Name = villaId.Name,
                Occupancy = villaId.Occupancy
            };

            patch.ApplyTo(patchVilla, ModelState);
            if (!TryValidateModel(patchVilla))
            {
                return BadRequest(ModelState);
            }

            villaId.Name = patchVilla.Name ?? villaId.Name;
            villaId.Occupancy = patchVilla.Occupancy ?? villaId.Occupancy;

            return NoContent();
        }
    }
}