﻿using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace QueryableDatabase.Models
{
    public class Building
    {
        [Key]
        public int Id { get; set; }

        public string? Name { get; set; }

        [ForeignKey(nameof(Address))]
        public int? AddressId { get; set; }

        public virtual Address? Address { get; set; }

        //[ForeignKey(...)]
        //public virtual ICollection<Address> AddressList { get; set; }

        public int Floors { get; set; }
        public int YearBuilt { get; set; }

        // property for causing migrations conflicts
        // MUAHAHAHAHAAA!!!
        public string? ShowStopper { get; set; }
    }
}
