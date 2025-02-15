using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace backend.Models
{
    public class ServiceOptions
    {
        public int Id { get; set; }

        [Required]
        public string Name { get; set; } = string.Empty;
        [Required]
        public string Duration { get; set; }
        [Required]
          public decimal? Price { get; set; }
[ForeignKey("Service")]
          public int ServiceId { get; set; }

          public Service Service { get; set; }
    }
}