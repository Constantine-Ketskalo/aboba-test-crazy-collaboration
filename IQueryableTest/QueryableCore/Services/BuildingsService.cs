using Microsoft.Extensions.Options;
using QueryableCore.DTOs;
using QueryableCore.RepositoriesInterfaces;
using QueryableCore.Services.Interfaces;
using Shared.ConfigModels;

namespace QueryableCore.Services
{
    public class BuildingsService : IBuildingsService
    {
        private readonly IBuildingsRepository _buildingsRepository;
        private readonly AppIdentitySettings _appIdentitySettings;

        public BuildingsService(IBuildingsRepository buildingsRepository, IOptions<AppIdentitySettings> appIdentitySettings)
        {
            _buildingsRepository = buildingsRepository;
            _appIdentitySettings = appIdentitySettings.Value;
        }

        public List<BuildingDto> Get()
        {
            return _buildingsRepository.Get();
        }

        public List<int> CreateBuildings(List<BuildingDto> buildingDtos)
        {
            return _buildingsRepository.CreateBuilding(buildingDtos);
        }

        public BuildingDto? Get(int id)
        {
            return _buildingsRepository.Get(id);
        }

        public async Task<bool> UpdateBuildingAsync(BuildingDto buildingDto)
        {
            return await _buildingsRepository.UpdateBuildingAsync(buildingDto);
        }

        public async Task<bool> DeleteAsync(int id)
        {
            return await _buildingsRepository.DeleteAsync(id);
        }
    }
}
