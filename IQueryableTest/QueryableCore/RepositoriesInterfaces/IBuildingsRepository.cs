using QueryableCore.DTOs;

namespace QueryableCore.RepositoriesInterfaces
{
    public interface IBuildingsRepository
    {
        List<BuildingDto> Get();
        BuildingDto? Get(int id);
        List<int> CreateBuilding(List<BuildingDto> buildingDtos);
        Task<bool> UpdateBuildingAsync(BuildingDto buildingDto);
        Task<bool> DeleteAsync(int id);
    }
}
