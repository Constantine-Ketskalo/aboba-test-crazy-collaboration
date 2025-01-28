using AutoMapper;
using MvcWebApp.Models;
using QueryableCore.DTOs;

namespace MvcWebApp.Mapping
{
    public class MvcMapperProfile : Profile
    {
        public MvcMapperProfile()
        {
            CreateMap<BuildingDto, BuildingModel>()
                .ForMember(buildingModel => buildingModel.ErrorMessage, map => map.Ignore());
            CreateMap<BuildingModel, BuildingDto>()
                .ForMember(buildingDto => buildingDto.AddressId, map => map.Ignore())
                .ForMember(buildingDto => buildingDto.Address, map => map.Ignore());
        }
    }
}
