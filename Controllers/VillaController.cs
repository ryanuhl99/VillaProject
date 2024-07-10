using System;
using Microsoft.AspNetCore.Mvc;
using RESTAPIProject.Models.VillaDTO;
using RESTAPIProject.Validation.ValidationAttributes;
using System.Linq;
using RESTAPIProject.Models.CreateVillaDTO;
using RESTAPIProject.Models.UpdateVillaDTO;
using Microsoft.AspNetCore.JsonPatch;
using RESTAPIProject.Data.ApplicationDbContext;
using RESTAPIProject.Models.Villa;
using Microsoft.EntityFrameworkCore;
using AutoMapper;
using System.Collections.Generic;
using RESTAPIProject.Repository.VillaRepository;
using RESTAPIProject.Repository.IRepository.IVillaRepository;

namespace RESTAPIProject.Controllers.VillaController
{   
    [Route("api/[controller]")]
    [ApiController]
    public class VillaApiController : ControllerBase
    {
        private readonly IVillaRepository _dbVilla;
        private readonly ILogger<VillaApiController> _logger;
        private readonly IMapper _mapper;
        public VillaApiController(ILogger<VillaApiController> logger, IVillaRepository dbVilla, IMapper mapper)
        {
            _logger = logger;
            _dbVilla = dbVilla;
            _mapper = mapper;
        } 

        [HttpGet]
        [ProducesResponseType(200)]
        public async Task<ActionResult<IEnumerable<VillaDTO>>> GetVillas()
        {
            _logger.LogInformation("Getting All Villas");
            IEnumerable<Villa> villaList = await _dbVilla.GetAllAsync();
            return Ok(_mapper.Map<List<VillaDTO>>(villaList));
        }

        [HttpGet("ByIDorName", Name = "Get Villa")]
        [ProducesResponseType(200)]
        [ProducesResponseType(400)]
        [ProducesResponseType(404)]
        public async Task<IActionResult> GetVilla([FromQuery] int? id, [FromQuery] string? name)
        {
            if (id.HasValue)
            {
                var villa = await _dbVilla.GetByIdAsync(id.Value);
                if (villa == null)
                {
                    return NotFound();
                }
                return Ok(villa);
            }
            else if (!string.IsNullOrEmpty(name))
            {
                var villaName = await _dbVilla.GetByNameAsync(name);

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

            Villa villacreate = _mapper.Map<Villa>(request);
     
            await _dbVilla.CreateAsync(villacreate);
            await _dbVilla.SaveAsync();

            return CreatedAtRoute("Get Villa", new { id = villacreate.Id, name = villacreate.Name }, villacreate);        
        }

        [HttpDelete("{id}", Name = "Delete Villa")]
        [ProducesResponseType(404)]
        [ProducesResponseType(204)]
        public async Task<IActionResult> DeleteVilla(int id)
        {
            var villa = await _dbVilla.GetByIdAsync(id);
            if (villa == null)
            {
                return NotFound();
            }

            await _dbVilla.RemoveAsync(villa);
            await _dbVilla.SaveAsync();

            return NoContent();
        }

        [HttpPut("{id}", Name = "Update Villa")]
        [ProducesResponseType(404)]
        [ProducesResponseType(204)]
        public async Task<IActionResult> UpdateVilla(int id, [FromBody] UpdateVillaRequest request)
        {
            var villa = await _dbVilla.GetByIdAsync(id);
            if (villa == null)
            {
                return NotFound($"ID: {id} not found");
            }

            // villaId.Name = request.Name;
            // villaId.Occupancy = request.Occupancy;

            Villa villaupdate = _mapper.Map<Villa>(request);

            await _dbVilla.UpdateAsync(villaupdate);
            await _dbVilla.SaveAsync();

            return NoContent();
        }

        [HttpPatch("{id}", Name = "Patch Villa")]
        [ProducesResponseType(404)]
        [ProducesResponseType(400)]
        [ProducesResponseType(204)]
        public async Task<IActionResult> PatchVilla(int id, [FromBody] JsonPatchDocument<UpdateVillaRequest> patchDoc)
        {
            if (patchDoc == null)
            {
                return BadRequest(ModelState);
            }
            var villa = await _dbVilla.GetByIdAsync(id);
            if (villa == null)
            {
                return NotFound($"ID: {id} not found");
            }

            UpdateVillaRequest villapatch = _mapper.Map<UpdateVillaRequest>(villa);


            patchDoc.ApplyTo(villapatch, ModelState);
            if (!TryValidateModel(villapatch))
            {
                return BadRequest(ModelState);
            }

            Villa villaconvert = _mapper.Map<Villa>(villapatch);

            await _dbVilla.UpdateAsync(villaconvert);
   
            try
            {
                await _dbVilla.SaveAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                throw;
            }

            return NoContent();
        }
    }
}