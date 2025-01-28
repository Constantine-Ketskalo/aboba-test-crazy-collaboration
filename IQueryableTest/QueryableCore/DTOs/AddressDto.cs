using System.ComponentModel.DataAnnotations;

namespace QueryableCore.DTOs
{
    public class AddressDto
    {
        [Required]
        public int Id { get; set; }
        public string? City { get; set; }
        public string? Street { get; set; }
        public string? BuildingNumber { get; set; }
    }
}
