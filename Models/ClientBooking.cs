using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace backend.Models
{
    public class ClientBooking
    {
        [Key]
         public int Id { get; set; }
         public string selectedService { get; set; }

         public string duration {get;set;}


        [ForeignKey("Booking")]
         public int BookingId { get; set; }
         [JsonIgnore]
         public Booking Booking { get; set; }
    }
}