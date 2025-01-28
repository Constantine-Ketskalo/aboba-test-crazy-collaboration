using AutoMapper;
using Microsoft.EntityFrameworkCore;
using QueryableCore.DTOs;
using QueryableCore.RepositoriesInterfaces;
using QueryableDatabase.Migrations;
using QueryableDatabase.Models;

namespace QueryableDatabase.Repositories
{
    public class BuildingsRepository : IBuildingsRepository
    {
        private readonly MsSqlContext _dbContext;
        private readonly IMapper _mapper;

        public BuildingsRepository(MsSqlContext msSqlContext, IMapper mapper)
        {
            _dbContext = msSqlContext;
            _mapper = mapper;
        }

        public List<BuildingDto> Get()
        {
            IQueryable<Building> buildings = _dbContext.Buildings
                                                    .Include(building => building.Address);

            List<Building> buildingsList = buildings.ToList();

            return _mapper.Map<List<BuildingDto>>(buildingsList);
        }

        public List<int> CreateBuilding(List<BuildingDto> buildingDtos)
        {
            List<Building> buildings = _mapper.Map<List<Building>>(buildingDtos);

            buildings.ForEach(b =>
            {
                b.Id = 0;
                b.AddressId = null;
                b.AddressId = 0;
            });

            _dbContext.Buildings.AddRange(buildings);

            int changesCount = _dbContext.SaveChanges();

            List<int> ids = buildings.Select(building => building.Id).ToList();

            return changesCount == buildingDtos.Count ? ids : new();
        }

        public BuildingDto? Get(int id)
        {
            Building? building = _dbContext.Buildings
                                        //.Include(b => b.Address)
                                        .FirstOrDefault(b => b.Id == id);

            return building == null ? null : _mapper.Map<BuildingDto>(building);
        }

        public async Task<bool> UpdateBuildingAsync(BuildingDto buildingDto)
        {
            Building? existingBuilding = await _dbContext.Buildings
                                                    .FirstOrDefaultAsync(b => b.Id == buildingDto.Id);

            if (existingBuilding == null)
            {
                return false;
            }

            existingBuilding.Name = buildingDto.Name;
            existingBuilding.Floors = buildingDto.Floors.HasValue ? buildingDto.Floors.Value : default;
            existingBuilding.YearBuilt = buildingDto.YearBuilt.HasValue ? buildingDto.YearBuilt.Value : default;

            _dbContext.Buildings.Update(existingBuilding);
            int countUpdated = await _dbContext.SaveChangesAsync();

            return countUpdated > 0;
        }

        public async Task<bool> DeleteAsync(int id)
        {
            Building? building = await _dbContext.Buildings
                                        .FirstOrDefaultAsync(b => b.Id == id);

            if (building == null)
            {
                return false;
            }

            _dbContext.Buildings.Remove(building);
            int countDeleted = await _dbContext.SaveChangesAsync();

            return countDeleted > 0;
        }
    }
}
