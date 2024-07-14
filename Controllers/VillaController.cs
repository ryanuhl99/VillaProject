using System;
using Microsoft.AspNetCore.Mvc;
using RESTAPIProject.Models.VillaDTO;
using RESTAPIProject.Validation.ValidationAttributes;
using System.Linq;
using RESTAPIProject.Models.CreateVillaDTO;
using RESTAPIProject.Models.UpdateVillaDTO;
using Microsoft.AspNetCore.JsonPatch;
using RESTAPIProject.Data.ApplicationDbContext;
using RESTAPIProject.Models.VillaClass;
using Microsoft.EntityFrameworkCore;
using AutoMapper;
using System.Collections.Generic;
using RESTAPIProject.Repository.VillaRepository;
using RESTAPIProject.Repository.IRepository.IVillaRepository;
using RESTAPIProject.Models.APIResponse;
using System.Net;

namespace RESTAPIProject.Controllers.VillaController
{   
    [Route("api/[controller]")]
    [ApiController]
    public class VillaApiController : ControllerBase
    {
        private readonly IVillaRepository _dbVilla;
        private readonly ILogger<VillaApiController> _logger;
        private readonly IMapper _mapper;
        protected APIResponse _response;
        public VillaApiController(ILogger<VillaApiController> logger, IVillaRepository dbVilla, IMapper mapper)
        {
            _logger = logger;
            _dbVilla = dbVilla;
            _mapper = mapper;
            this._response = new APIResponse();
        } 

        [HttpGet]
        [ProducesResponseType(200)]
        [ProducesResponseType(500)]
        public async Task<ActionResult<APIResponse>> GetVillas()
        {
            try 
            {
                _logger.LogInformation("Getting All Villas");
                IEnumerable<Villa> villaList = await _dbVilla.GetAllAsync();

                _response.StatusCode = HttpStatusCode.OK;
                _response.Result = _mapper.Map<List<VillaDTO>>(villaList); 
                return Ok(_response);
            }
            catch (Exception ex)
            {
                _response.StatusCode = HttpStatusCode.InternalServerError;
                _response.IsSuccess = false;
                _response.ErrorMessages = new List<string>() { ex.ToString() };
                return StatusCode((int)HttpStatusCode.InternalServerError, _response);
            }
        }

        [HttpGet("ByIDorName", Name = "Get Villa")]
        [ProducesResponseType(200)]
        [ProducesResponseType(400)]
        [ProducesResponseType(404)]
        public async Task<ActionResult<APIResponse>> GetVilla([FromQuery] int? id, [FromQuery] string? name)
        {
            try
            {
                if (id.HasValue)
                {
                    var villa = await _dbVilla.GetByIdAsync(id.Value);
                    if (villa == null)
                    {
                        _response.StatusCode = HttpStatusCode.NotFound;
                        _response.IsSuccess = false;
                        return NotFound(_response);
                    }
                    _response.Result = _mapper.Map<VillaDTO>(villa);
                    _response.StatusCode = HttpStatusCode.OK;
                    return Ok(_response);
                }
                else if (!string.IsNullOrEmpty(name))
                {
                    var villaName = await _dbVilla.GetByNameAsync(name);

                    if (!villaName.Any())
                    {
                        _response.StatusCode = HttpStatusCode.NotFound;
                        _response.IsSuccess = false;
                        return NotFound(_response);
                    }
                    _response.Result = _mapper.Map<VillaDTO>(villaName);
                    _response.StatusCode = HttpStatusCode.OK;
                    return Ok(_response);
                }
                else
                {
                    _response.StatusCode = HttpStatusCode.BadRequest;
                    _response.IsSuccess = false;
                    _response.ErrorMessages = new List<string> { "Must enter valid Id or Name" };
                    return BadRequest(_response);
                }
            }
            catch (Exception ex)
            {
                _response.StatusCode = HttpStatusCode.InternalServerError;
                _response.IsSuccess = false;
                _response.ErrorMessages = new List<string>() { ex.ToString() };
                return StatusCode((int)HttpStatusCode.InternalServerError, _response);
            }
        }

        [HttpPost(Name = "Create Villa")]
        [ProducesResponseType(201)]
        [ProducesResponseType(400)]
        public async Task<ActionResult<APIResponse>> CreateVilla([FromBody] CreateVillaRequest request)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    _response.StatusCode = HttpStatusCode.BadRequest;
                    _response.IsSuccess = false;
                    return BadRequest(_response);
                }

                Villa villacreate = _mapper.Map<Villa>(request);
        
                await _dbVilla.CreateAsync(villacreate);
                await _dbVilla.SaveAsync();

                _response.Result = _mapper.Map<VillaDTO>(villacreate);
                _response.StatusCode = HttpStatusCode.Created;

                return CreatedAtRoute("Get Villa", new { id = villacreate.Id, name = villacreate.Name }, _response);        
            }
            catch (Exception ex)
            {
                _response.StatusCode = HttpStatusCode.InternalServerError;
                _response.IsSuccess = false;
                _response.ErrorMessages = new List<string>() { ex.ToString() };
                return StatusCode((int)HttpStatusCode.InternalServerError, _response);
            }
        }

        [HttpDelete("{id}", Name = "Delete Villa")]
        [ProducesResponseType(404)]
        [ProducesResponseType(204)]
        public async Task<ActionResult<APIResponse>> DeleteVilla(int id)
        {
            try
            {
                var villa = await _dbVilla.GetByIdAsync(id);
                if (villa == null)
                {
                    _response.StatusCode = HttpStatusCode.NotFound;
                    return NotFound(_response);
                }

                await _dbVilla.RemoveAsync(villa);
                await _dbVilla.SaveAsync();

                _response.IsSuccess = true;
                _response.StatusCode = HttpStatusCode.NoContent;

                return Ok(_response);
            }
            catch (Exception ex)
            {
                _response.StatusCode = HttpStatusCode.InternalServerError;
                _response.IsSuccess = false;
                _response.ErrorMessages = new List<string>() { ex.ToString() };
                return StatusCode((int)HttpStatusCode.InternalServerError, _response);
            }
        }

        [HttpPut("{id}", Name = "Update Villa")]
        [ProducesResponseType(404)]
        [ProducesResponseType(204)]
        [ProducesResponseType(500)]
        public async Task<ActionResult<APIResponse>> UpdateVilla(int id, [FromBody] UpdateVillaRequest request)
        {
            try
            {
                var villa = await _dbVilla.GetByIdAsync(id);
                if (villa == null)
                {
                    _response.StatusCode = HttpStatusCode.NotFound;
                    _response.IsSuccess = false;
                    _response.ErrorMessages = new List<string>() { $"ID: {id} not found" };
                    return NotFound(_response);
                }

                Villa villaupdate = _mapper.Map<Villa>(request);

                await _dbVilla.UpdateAsync(villaupdate);
                await _dbVilla.SaveAsync();

                _response.IsSuccess = true;
                _response.StatusCode = HttpStatusCode.NoContent;

                return Ok(_response);
            }
            catch (Exception ex)
            {
                _response.StatusCode = HttpStatusCode.InternalServerError;
                _response.IsSuccess = false;
                _response.ErrorMessages = new List<string>() { ex.ToString() };
                return StatusCode((int)HttpStatusCode.InternalServerError, _response);
            }
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