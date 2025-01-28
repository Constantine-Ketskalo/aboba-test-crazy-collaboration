using System.ComponentModel.DataAnnotations;

namespace QueryableCore.DTOs
{
    public class BuildingDto
    {
        public BuildingDto()
        {
            Name = string.Empty;
        }

        [Required]
        public int? Id { get; set; }

        [Required]
        public string Name { get; set; }

        public int? AddressId { get; set; }
        public AddressDto? Address { get; set; }

        [Required]
        public int? Floors { get; set; }

        [Required]
        public int? YearBuilt { get; set; }
    }
}
