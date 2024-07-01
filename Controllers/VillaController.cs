using System;
using Microsoft.AspNetCore.Mvc;
using RESTAPIProject.Models.Villa;

namespace RESTAPIProject.Controllers.VillaController
{   
    [Route("api/VillaApi")]
    [ApiController]
    public class VillaApiController : ControllerBase
    {
        [HttpGet]
        public IEnumerable<Villa> GetVilla()
        {
            return new List<Villa> {
                new Villa { Id=1, Name="Pool View" },
                new Villa { Id=2, Name="Ocean View" }
            };
        }
    }
}