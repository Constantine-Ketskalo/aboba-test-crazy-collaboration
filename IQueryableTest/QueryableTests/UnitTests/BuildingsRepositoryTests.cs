using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Moq;
using QueryableCore.DTOs;
using QueryableDatabase.Migrations;
using QueryableDatabase.Models;
using QueryableDatabase.Repositories;

namespace QueryableTests.UnitTests
{
    [TestFixture]
    public class BuildingsRepositoryTests
    {
        private MsSqlContext _dbContext;
        private BuildingsRepository _buildingsRepository;
        private Mock<IMapper> _mapperMock;

        [SetUp]
        public void Setup()
        {
            var options = new DbContextOptionsBuilder<MsSqlContext>()
                                        .UseInMemoryDatabase(databaseName: "TestDatabase")
                                        .Options;
            _dbContext = new MsSqlContext(options);
            SeedData();

            _mapperMock = new Mock<IMapper>();
            _mapperMock.Setup(m => m.Map<List<BuildingDto>>(It.IsAny<List<Building>>()))
                    .Returns((List<Building> buildings) =>
                                        buildings.Select(b => new BuildingDto()
                                        {
                                            Id = b.Id,
                                            Name = b.Name,
                                            AddressId = b.AddressId,
                                            Address = new AddressDto()
                                            {
                                                Id = b.Address.Id,
                                                City = b.Address.City,
                                                Street = b.Address.Street,
                                                BuildingNumber = b.Address.BuildingNumber
                                            },
                                            Floors = b.Floors,
                                            YearBuilt = b.YearBuilt
                                        })
                                        .ToList());

            _buildingsRepository = new BuildingsRepository(_dbContext, _mapperMock.Object);
        }

        private void SeedData()
        {
            _dbContext.Buildings.AddRange(new List<Building>()
            {
                new Building()
                {
                    Id = 1,
                    Name = "Building1",
                    AddressId = 1,
                    Address = new Address()
                    {
                        Id = 1,
                        City = "City1",
                        Street = "Street1",
                        BuildingNumber = "1"
                    },
                    Floors = 1,
                    YearBuilt = 2000
                },
                new Building()
                {
                    Id = 2,
                    Name = "Building2",
                    AddressId = 2,
                    Address = new Address()
                    {
                        Id = 2,
                        City = "City2",
                        Street = "Street2",
                        BuildingNumber = "2"
                    },
                    Floors = 2,
                    YearBuilt = 2001
                }
            });
            _dbContext.SaveChanges();
        }

        [Test]
        public void BasiscGetTest()
        {
            List<BuildingDto> buildings = _buildingsRepository.Get();
            Assert.That(buildings.Count, Is.EqualTo(2));
            _mapperMock.Verify(m => m.Map<List<BuildingDto>>(It.IsAny<List<Building>>()), Times.Once);
        }

        [Test]
        public void ExceptionTest()
        {
            _dbContext.Dispose();
            Assert.Throws<ObjectDisposedException>(() => _buildingsRepository.Get());
        }

        [TestCase(1, 2, "asdf")]
        [TestCase(3, 4, "asdf2")]
        [TestCase(5, 6, "asdf3")]
        public void Test2(int a, int b, string c)
        {
            Assert.Pass();
        }

        [TearDown]
        public void TearDown()
        {
            _dbContext.Dispose();
        }
    }
}