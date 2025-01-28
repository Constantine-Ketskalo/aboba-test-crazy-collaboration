using QueryableCore.DTOs;
using System.ComponentModel.DataAnnotations;

namespace MvcWebApp.Models
{
    public class BuildingModel
    {
        public BuildingModel()
        {
            Name = string.Empty;
        }

        [Required]
        public int? Id { get; set; }

        [Required]
        public string Name { get; set; }

        public int? Floors { get; set; }

        public int? YearBuilt { get; set; }

        public string? ErrorMessage { get; set; }
    }
}
