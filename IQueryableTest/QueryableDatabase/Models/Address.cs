using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace QueryableDatabase.Models
{
    public class Address
    {
        [Key]
        public int Id { get; set; }

        public string? City { get; set; }
        public string? Street { get; set; }
        public string? BuildingNumber { get; set; }

        [InverseProperty(nameof(Building.Address))]
        public virtual ICollection<Building> Buildings { get; set; }
    }
}
