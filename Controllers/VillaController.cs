using System;
using Microsoft.AspNetCore.Mvc;
using RESTAPIProject.Models.VillaDTO;
using RESTAPIProject.Validation.ValidationAttributes;
using System.Linq;
using RESTAPIProject.Models.CreateVillaDTO;
using Microsoft.AspNetCore.JsonPatch;
using RESTAPIProject.Data.ApplicationDbContext;
using RESTAPIProject.Models.Villa;
using Microsoft.EntityFrameworkCore;

namespace RESTAPIProject.Controllers.VillaController
{   
    [Route("api/[controller]")]
    [ApiController]
    public class VillaApiController : ControllerBase
    {
        private readonly ApplicationDbContext _db;
        private readonly ILogger<VillaApiController> _logger;
        public VillaApiController(ILogger<VillaApiController> logger, ApplicationDbContext db)
        {
            _logger = logger;
            _db = db;
        } 

        [HttpGet]
        [ProducesResponseType(200)]
        public async Task<ActionResult<IEnumerable<VillaDTO>>> GetVillas()
        {
            _logger.LogInformation("Getting All Villas");
            return Ok(await _db.Villas.ToListAsync());
        }

        [HttpGet("ByIDorName", Name = "Get Villa")]
        [ProducesResponseType(200)]
        [ProducesResponseType(400)]
        [ProducesResponseType(404)]
        public async Task<IActionResult> GetVilla([FromQuery] int? id, [FromQuery] string? name)
        {
            if (id.HasValue)
            {
                var villa = await _db.Villas.FindAsync(id.Value);
                if (villa == null)
                {
                    return NotFound();
                }
                return Ok(villa);
            }
            else if (!string.IsNullOrEmpty(name))
            {
                var villaName = await _db.Villas
                    .Where(x => x.Name.Equals(name, StringComparison.OrdinalIgnoreCase))
                    .ToListAsync();

                if (!villaName.Any())
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
        public async Task<ActionResult<Villa>> CreateVilla([FromBody] CreateVillaRequest request)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            if (await _db.Villas.AnyAsync(x => x.Name.ToLower() == request.Name.ToLower()))
            {
                return Conflict(new { message = "This name already exists in the database" });
            }
                        
            // int villaId = _db.Villas.Any() ? _db.Villas.Max(x => x.Id) + 1 : 1;
            var newVilla = new Villa 
                {   
                    Name=request.Name,
                    Details=request.Details,
                    Occupancy=request.Occupancy,
                    Sqft=request.Sqft,
                    Rate=request.Rate,
                    ImageUrl=request.ImageUrl,
                    Amenity=request.Amenity 
                };
            await _db.Villas.AddAsync(newVilla);
            await _db.SaveChangesAsync();

            return CreatedAtRoute("Get Villa", new { id = newVilla.Id, name = newVilla.Name }, newVilla);        
        }

        [HttpDelete("{id}", Name = "Delete Villa")]
        [ProducesResponseType(404)]
        [ProducesResponseType(204)]
        public async Task<IActionResult> DeleteVilla(int id)
        {
            var villa = await _db.Villas.FindAsync(id);
            if (villa == null)
            {
                return NotFound();
            }

            _db.Villas.Remove(villa);
            await _db.SaveChangesAsync();

            return NoContent();
        }

        [HttpPut("{id}", Name = "Update Villa")]
        [ProducesResponseType(404)]
        [ProducesResponseType(204)]
        public async Task<IActionResult> UpdateVilla(int id, [FromBody] CreateVillaRequest request)
        {
            var villa = await _db.Villas.FindAsync(id);
            if (villa == null)
            {
                return NotFound($"ID: {id} not found");
            }

            // villaId.Name = request.Name;
            // villaId.Occupancy = request.Occupancy;

            villa.Name = request.Name;
            villa.Details = request.Details;
            villa.Occupancy = request.Occupancy;
            villa.Sqft = request.Sqft;
            villa.Rate = request.Rate;
            villa.ImageUrl = request.ImageUrl;
            villa.Amenity = request.Amenity; 
            
            _db.Villas.Update(villa);
            await _db.SaveChangesAsync();

            return NoContent();
        }

        [HttpPatch("{id}", Name = "Patch Villa")]
        [ProducesResponseType(404)]
        [ProducesResponseType(400)]
        [ProducesResponseType(204)]
        public async Task<IActionResult> PatchVilla(int id, [FromBody] JsonPatchDocument<CreateVillaRequest> patchDoc)
        {
            if (patchDoc == null)
            {
                return BadRequest(ModelState);
            }
            var villa = await _db.Villas.FindAsync(id);
            if (villa == null)
            {
                return NotFound($"ID: {id} not found");
            }

            CreateVillaRequest model = new()
            {
                Name = villa.Name,
                Details = villa.Details,
                Occupancy = villa.Occupancy,
                Sqft = villa.Sqft,
                Rate = villa.Rate,
                ImageUrl = villa.ImageUrl,
                Amenity = villa.Amenity
            };
            // var patchVilla = new CreateVillaRequest {
            //     Name = villaId.Name,
            //     Occupancy = villaId.Occupancy
            // };


            patchDoc.ApplyTo(model, ModelState);
            if (!TryValidateModel(model))
            {
                return BadRequest(ModelState);
            }

            villa.Name = model.Name ?? villa.Name;
            villa.Details = model.Details ?? villa.Details;
            villa.Occupancy = model.Occupancy ?? villa.Occupancy;
            villa.Sqft = model.Sqft ?? villa.Sqft;
            villa.Rate = model.Rate ?? villa.Rate;
            villa.ImageUrl = model.ImageUrl ?? villa.ImageUrl;
            villa.Amenity = model.Amenity ?? villa.Amenity;

            try
            {
                await _db.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                throw;
            }

            return NoContent();
        }
    }
}