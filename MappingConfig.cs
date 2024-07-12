using AutoMapper;
using RESTAPIProject.Models.CreateVillaDTO;
using RESTAPIProject.Models.UpdateVillaDTO;
using RESTAPIProject.Models.Villa;
using RESTAPIProject.Models.VillaDTO;

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
            CreateMap<VillaNumber, CreateVillaNumberDTO>().ReverseMap();
            CreateMap<VillaNumber, UpdateVillaNumberDTO>().ReverseMap();
            CreateMap<VillaNumberDTO, CreateVillaNumberDTO>().ReverseMap();
            CreateMap<VillaNumberDTO, UpdateVillaNumberDTO>().ReverseMap();
            CreateMap<CreateVillaNumberDTO, UpdateVillaNumberDTO>().ReverseMap();
        }
    }
}