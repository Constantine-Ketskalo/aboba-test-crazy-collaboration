using Microsoft.AspNetCore.Mvc;
using QueryableCore.DTOs;
using QueryableCore.Services.Interfaces;
using System.Reflection.Metadata.Ecma335;

namespace QueryableAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class BuildingsController : ControllerBase
    {
        private readonly IBuildingsService _buildingsService;

        public BuildingsController(IBuildingsService buildingsService)
        {
            _buildingsService = buildingsService;
        }

        [HttpGet]
        public IActionResult Get()
        {
            return Ok(_buildingsService.Get());
        }

        protected string GetModelStateErrorsAggregatedMessage()
        {
            var errors = ModelState.Values.SelectMany(
                        value => value.Errors,
                        (value, error) => error.ErrorMessage
                    );
            return string.Join("\n", errors);
        }

        [HttpPost]
        public IActionResult CreateBuildings([FromBody] List<BuildingDto> buildingDtos)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest("WTF???");
                //string errorsAggregatedMessage = GetModelStateErrorsAggregatedMessage();
                //return BadRequest(errorsAggregatedMessage);
            }

            List<int> ids = _buildingsService.CreateBuildings(buildingDtos);

            return ids.Count == buildingDtos.Count ? Ok(ids) : BadRequest();
        }
    }
}
