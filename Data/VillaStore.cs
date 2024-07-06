using System;
using RESTAPIProject.Models.VillaDTO;

namespace RESTAPIProject.Data.VillaStore
{
    public static class VillaStore
    {
        public static List<VillaDTO> villaList = new List<VillaDTO> 
        {
            new VillaDTO { Id=0, Name="Pool View", Occupancy=2 },
            new VillaDTO { Id=2, Name="Big Time View", Occupancy=69 },
            new VillaDTO { Id=1, Name="Beach View", Occupancy=12 },
            new VillaDTO { Id=3, Name="Mountain View", Occupancy=9 },
            new VillaDTO { Id=4, Name="Pool View", Occupancy=7 }
        };
    }
}