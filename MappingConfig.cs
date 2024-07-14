using AutoMapper;
using RESTAPIProject.Models.CreateVillaDTO;
using RESTAPIProject.Models.UpdateVillaDTO;
using RESTAPIProject.Models.VillaClass;
using RESTAPIProject.Models.VillaDTO;
using RESTAPIProject.Models.VillaNumber;
using RESTAPIProject.Models.VillaNumberDTO;
using RESTAPIProject.Models.CreatedVillaNumberDTO;
using RESTAPIProject.Models.UpdatedVillaNumberDTO;

namespace RESTAPIProject.MappingConfig
{
    public class MappingConfig : Profile
    {
        public MappingConfig()
        {
            CreateMap<Villa, CreateVillaRequest>().ReverseMap();
            CreateMap<Villa, UpdateVillaRequest>().ReverseMap();
            CreateMap<CreateVillaRequest, UpdateVillaRequest>().ReverseMap();
            CreateMap<Villa, VillaDTO>().ReverseMap();
            CreateMap<VillaDTO, CreateVillaRequest>().ReverseMap();
            CreateMap<VillaDTO, UpdateVillaRequest>().ReverseMap();

            CreateMap<VillaNumber, VillaNumberDTO>().ReverseMap();
            CreateMap<VillaNumber, CreatedVillaNumberDTO>().ReverseMap();
            CreateMap<VillaNumber, UpdatedVillaNumberDTO>().ReverseMap();
            CreateMap<VillaNumberDTO, CreatedVillaNumberDTO>().ReverseMap();
            CreateMap<VillaNumberDTO, UpdatedVillaNumberDTO>().ReverseMap();
            CreateMap<CreatedVillaNumberDTO, UpdatedVillaNumberDTO>().ReverseMap();
        }
    }
}