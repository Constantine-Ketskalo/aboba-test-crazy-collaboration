using QueryableCore.DTOs;

namespace QueryableCore.Services.Interfaces
{
    public interface IBuildingsService
    {
        List<BuildingDto> Get();
        List<int> CreateBuildings(List<BuildingDto> buildingDtos);
        BuildingDto? Get(int id);
        Task<bool> UpdateBuildingAsync(BuildingDto buildingDto);
        Task<bool> DeleteAsync(int id);
    }
}
