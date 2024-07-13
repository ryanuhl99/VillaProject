

namespace RESTAPIProject.Controllers.VillaNumberController
{
    [Route("api/[controller]")]
    [ApiController]
    public class VillaNumberController : BaseController
    {
        private readonly Imapper _mapper;
        private readonly IVillaNumberRepository _dbNumber;
        protected APIResponse _response;

        public VillaNumberController(IVillaNumberRepository dbNumber, Imapper mapper)
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
                VillaNumberDTO villanumDTO = _mapper.Map<VillaNumberDTO>(villanum);
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
        public async Task<ActionResult<APIResponse>> GetByNumOrDetails([FromQuery] int? number, [FromQuery] string? detail)
        {
            try
            {
                if (number.HasValue)
                {
                    var villaNum = await _dbNumber.GetByIdAsync(number.Value);
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
                    IEnumerable<VillaNumber> villaDetail = await _dbNumer.GetByDetailsKeywordAsync(detail);
                    if (villaDetail == null)
                    {
                        _response.StatusCode = HttpStatusCode.NotFound;
                        _response.IsSuccess = false;
                        _response.ErrorMessages = new List<string>() { $"Villas with matching details are not found."};
                        return StatusCode((int)HttpStatusCode.NotFound, _response); 
                    }

                    VillaNumberDTO villaDetailDTO = _mapper.Map<VoillaNumberDTO>(villaDetail);
                    _response.StatusCode = HttpStatusCode.OK;
                    _response.Result = villaDetailDTO;
                    return StatusCode((int)HttpStatusCode.OK, _response);
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

        [HttpPost(Name = "Create Villa Number")]
        [ProducesResponseType(201)]
        [ProducesResponseType(400)]
        [ProducesResponseType(500)]
        public async Task<ActionResult<APIResponse>> CreateVillaNumber([FromBody] CreatedVillaNumberDTO villanum)
        {
            try
            {
                if (!Model.IsValid)
                {
                    _response.IsSuccess = false;
                    _response.StatusCode = HttpStatusCode.BadRequest;
                    return StatusCode((int)HttpStatusCode.BadRequest, _response);
                }

                VillaNumber villamapped = _mapper.Map<VillaNumber>(villanum);
                await _dbNumber.CreateAsync(villamapped);
                await _dbNumber.SaveAsync();
                _response.StatusCode = HttpStatusCode.Created;
                return StatusCode((int)HttpStatusCode.Created, _response);
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
        public async Task<ActionResult<APIResponse>> DeleteVillaNumber(int number)
        {
            try
            {
                var villanum = await _dbNumber.GetByIdAsync(number);
                if (villanum == null)
                {
                    _response.IsSuccess = false;
                    _response.StatusCode = HttpStatusCode.NotFound;
                    return StatusCode((int)HttpStatusCode.NotFound, _response);
                }

                await _dbNumber.RemoveAsync(villanum);
                await _dbNumber.SaveAsync();

                _response.StatusCode = HttpStatusCode.NoContent;
                return StatusCode((int)HttpStatusCode.NoContent, _response);
            }

            catch (Exception ex)
            {
                _response.IsSuccess = false;
                _response.StatusCode = HttpStatusCode.InternalServerError;
                _response.ErrorMessages = new List<string>() { ex.ToString() };
                return StatusCode((int)HttpStatusCode.InternalServerError, _response);
            }
        }

        [HttpPut("villano", Name = "Update Villa Number")]
        [ProducesResponseType(204)]
        [ProducesResponseType(400)]
        [ProducesResponseType(404)]
        [ProducesResponseType(500)]
        public async Task<ActionResult<APIResponse>> UpdateVillaNumber(int number, [FromBody] UpdatedVillaNumberDTO villanum)
        {
            var villanumber = await _dbNumber.GetByIdAsync(number);
            if (villanumber == null)
            {
                _response.IsSuccess = false;
                _response.StatusCode = HttpStatusCode.NotFound;
                return StatusCode((int)HttpStatusCode.NotFound, _response);
            }
        }
    }
}