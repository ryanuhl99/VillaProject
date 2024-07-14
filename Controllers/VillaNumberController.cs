using Microsoft.AspNetCore.Mvc;
using RESTAPIProject.Models.VillaNumberDTO;
using RESTAPIProject.Models.CreatedVillaNumberDTO;
using RESTAPIProject.Models.UpdatedVillaNumberDTO;
using RESTAPIProject.Data.ApplicationDbContext;
using RESTAPIProject.Models.VillaNumber;
using Microsoft.EntityFrameworkCore;
using AutoMapper;
using System.Collections.Generic;
using RESTAPIProject.Repository.VillaNumberRepository;
using RESTAPIProject.Repository.IRepository.IVillaNumberRepository;
using RESTAPIProject.Models.APIResponse;
using System.Net;

namespace RESTAPIProject.Controllers.VillaNumberController
{
    [Route("api/[controller]")]
    [ApiController]
    public class VillaNumberController : ControllerBase
    {
        private readonly IMapper _mapper;
        private readonly IVillaNumberRepository _dbNumber;
        protected APIResponse _response;

        public VillaNumberController(IVillaNumberRepository dbNumber, IMapper mapper)
        {
            _dbNumber = dbNumber;
            _mapper = mapper;
            this._response = new APIResponse();
        }

        [HttpGet(Name = "Get All Villa Numbers")]
        [ProducesResponseType(200)]
        [ProducesResponseType(500)]
        public async Task<ActionResult<APIResponse>> GetVillaNumbers()
        {
            try
            {
                IEnumerable<VillaNumber> villanum = await _dbNumber.GetAllAsync();
                IEnumerable<VillaNumberDTO> villanumDTO = _mapper.Map<IEnumerable<VillaNumberDTO>>(villanum);
                _response.StatusCode = HttpStatusCode.OK;
                _response.Result = villanumDTO;
                return StatusCode((int)HttpStatusCode.OK, _response);
            }
            catch (Exception ex)
            {
                _response.StatusCode = HttpStatusCode.InternalServerError;
                _response.IsSuccess = false;
                _response.ErrorMessages = new List<string>() { ex.ToString() };
                return StatusCode((int)HttpStatusCode.InternalServerError, _response);
            }
        }

        [HttpGet("ByNumOrDetails", Name = "Get By Number or Detail")]
        [ProducesResponseType(200)]
        [ProducesResponseType(404)]
        [ProducesResponseType(500)]
        public async Task<ActionResult<APIResponse>> GetByNumOrDetails([FromQuery] int? villano, [FromQuery] string? detail)
        {
            try
            {
                if (villano.HasValue)
                {
                    var villaNum = await _dbNumber.GetByIdAsync(villano.Value);
                    if (villaNum == null)
                    {
                        _response.StatusCode = HttpStatusCode.NotFound;
                        _response.IsSuccess = false;
                        _response.ErrorMessages = new List<string>() { $"Villa number is not found."};
                        return StatusCode((int)HttpStatusCode.NotFound, _response);
                    }

                    VillaNumberDTO villaNumDTO = _mapper.Map<VillaNumberDTO>(villaNum);
                    _response.StatusCode = HttpStatusCode.OK;
                    _response.Result = villaNumDTO;
                    return StatusCode((int)HttpStatusCode.OK, _response);
                }

                if (!string.IsNullOrEmpty(detail))
                {
                    IEnumerable<VillaNumber> villaDetail = await _dbNumber.GetByDetailsKeywordAsync(detail);
                    if (villaDetail == null)
                    {
                        _response.StatusCode = HttpStatusCode.NotFound;
                        _response.IsSuccess = false;
                        _response.ErrorMessages = new List<string>() { "Villas with matching details are not found." };
                        return StatusCode((int)HttpStatusCode.NotFound, _response); 
                    }

                    IEnumerable<VillaNumberDTO> villaDetailDTO = _mapper.Map<IEnumerable<VillaNumberDTO>>(villaDetail);
                    _response.StatusCode = HttpStatusCode.OK;
                    _response.Result = villaDetailDTO;
                    return StatusCode((int)HttpStatusCode.OK, _response);
                }

                _response.StatusCode = HttpStatusCode.BadRequest;
                _response.IsSuccess = false;
                _response.ErrorMessages = new List<string>() { "Invalid parameters. Provide either villano or detail." };
                return StatusCode((int)HttpStatusCode.BadRequest, _response);
            }

            catch (Exception ex)
            {
                _response.StatusCode = HttpStatusCode.InternalServerError;
                _response.IsSuccess = false;
                _response.ErrorMessages = new List<string>() { ex.ToString() };
                return StatusCode((int)HttpStatusCode.InternalServerError, _response);
            }
        }

        [HttpPost(Name = "Create Villa Number")]
        [ProducesResponseType(201)]
        [ProducesResponseType(400)]
        [ProducesResponseType(500)]
        public async Task<ActionResult<APIResponse>> CreateVillaNumber([FromBody] CreatedVillaNumberDTO villanum)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    _response.IsSuccess = false;
                    _response.StatusCode = HttpStatusCode.BadRequest;
                    return StatusCode((int)HttpStatusCode.BadRequest, _response);
                }

                VillaNumber villamapped = _mapper.Map<VillaNumber>(villanum);
                await _dbNumber.CreateNumberAsync(villamapped);
                await _dbNumber.SaveAsync();
                _response.StatusCode = HttpStatusCode.Created;
                return CreatedAtRoute("Get By Number or Detail", new { villano = villamapped.VillaNo, details = villamapped.SpecialDetails }, _response);
            }

            catch (Exception ex)
            {
                _response.IsSuccess = false;
                _response.StatusCode = HttpStatusCode.InternalServerError;
                _response.ErrorMessages = new List<string>() { ex.ToString() };
                return StatusCode((int)HttpStatusCode.InternalServerError, _response);
            }
        }

        [HttpDelete("{villano}", Name = "Delete Villa Number")]
        [ProducesResponseType(204)]
        [ProducesResponseType(404)]
        [ProducesResponseType(500)]
        public async Task<ActionResult<APIResponse>> DeleteVillaNumber(int villano)
        {
            try
            {
                var villanum = await _dbNumber.GetByIdAsync(villano);
                if (villanum == null)
                {
                    _response.IsSuccess = false;
                    _response.StatusCode = HttpStatusCode.NotFound;
                    return StatusCode((int)HttpStatusCode.NotFound, _response);
                }

                await _dbNumber.RemoveAsync(villanum);
                await _dbNumber.SaveAsync();

                return NoContent();
            }

            catch (Exception ex)
            {
                _response.IsSuccess = false;
                _response.StatusCode = HttpStatusCode.InternalServerError;
                _response.ErrorMessages = new List<string>() { ex.ToString() };
                return StatusCode((int)HttpStatusCode.InternalServerError, _response);
            }
        }

        [HttpPut("{villano}", Name = "Update Villa Number")]
        [ProducesResponseType(204)]
        [ProducesResponseType(400)]
        [ProducesResponseType(404)]
        [ProducesResponseType(500)]
        public async Task<ActionResult<APIResponse>> UpdateVillaNumber(int villano, [FromBody] UpdatedVillaNumberDTO villanum)
        {
            try
            {
                var villanumber = await _dbNumber.GetByIdAsync(villano);
                if (villanumber == null)
                {
                    _response.IsSuccess = false;
                    _response.StatusCode = HttpStatusCode.NotFound;
                    return StatusCode((int)HttpStatusCode.NotFound, _response);
                }

                if (!ModelState.IsValid)
                {
                    _response.IsSuccess = false;
                    _response.StatusCode = HttpStatusCode.BadRequest;
                    return StatusCode((int)HttpStatusCode.BadRequest, _response);
                }

                _mapper.Map(villanum, villanumber);
                villanumber.VillaNo = villano;
                villanumber.UpdatedDate = DateTime.UtcNow;

                await _dbNumber.UpdateNumberAsync(villanumber);
                await _dbNumber.SaveAsync();

                _response.StatusCode = HttpStatusCode.NoContent;
                return Ok(_response);
            }

            catch (Exception ex)
            {
                _response.IsSuccess = false;
                _response.StatusCode = HttpStatusCode.InternalServerError;
                _response.ErrorMessages = new List<string>() { ex.ToString() };
                return StatusCode((int)HttpStatusCode.InternalServerError, _response);
            }    
        }
    }
}