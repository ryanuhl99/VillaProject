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
        public IEnumerable<VillaDTO> GetVilla()
        {
            return VillaStore.villaList;
        }
    }
}