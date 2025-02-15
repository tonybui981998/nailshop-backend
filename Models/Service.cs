using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace backend.Models
{
    public class Service
    {
        public int Id { get; set; }

        public string Title { get; set; } = string.Empty;

       public List<ServiceOptions> ServiceOptions { get; set; } = new List<ServiceOptions> ();
    }
}