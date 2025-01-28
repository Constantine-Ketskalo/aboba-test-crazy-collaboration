using AutoMapper;
using QueryableCore.DTOs;
using QueryableDatabase.Models;

namespace QueryableDatabase.Mapping
{
    public class QueryableDatabaseMapperProfile : Profile
    {
        public QueryableDatabaseMapperProfile()
        {
            CreateMap<Building, BuildingDto>().ReverseMap();
            CreateMap<Address, AddressDto>().ReverseMap();
        }
    }
}
