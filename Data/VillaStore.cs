using System;
using RESTAPIProject.Models.VillaDTO;

namespace RESTAPIProject.Data.VillaStore
{
    public static class VillaStore
    {
        public static List<VillaDTO> villaList = new List<VillaDTO> 
        {
            new VillaDTO { Id=0, Name="Pool View" },
            new VillaDTO { Id=1, Name="Beach View" },
            new VillaDTO { Id=3, Name="Mountain View" },
            new VillaDTO { Id=4, Name="Pool View" }
        };
    }
}