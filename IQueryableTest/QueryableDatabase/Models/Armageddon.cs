using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QueryableDatabase.Models
{
    public class Armageddon
    {
        [Key]
        public int Id { get; set; }

        public string? Name { get; set; }
    }
}
