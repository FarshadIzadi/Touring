using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Touring.Models
{
    public class Trip
    {
        public int Id { get; set; }
        
        [Display(Name ="Vehicle")]
        [Required]
        public string Vehicle { get; set; }

        [Display(Name = "Vehicle Number/Name")]
        public string VehicleNumber { get; set; }

        [Display(Name = "Origin Country")]
        [Required]
        public string OriginCountry { get; set; }

        [Display(Name = "Origin City")]
        [Required]
        public string OriginCity { get; set; }

        [Display(Name = "Destination Country")]
        [Required]
        public string DestinationCountry { get; set; }

        [Display(Name = "Destination City")]
        [Required]
        public string DestinationCity { get; set; }

        [Display(Name = "Departure time")]
        [Required]
        public DateTime DepartureTime { get; set; }

        [Display(Name = "Arrival time")]
        [Required]
        public DateTime ArrivalTime { get; set; }

        [Display(Name = "Price")]
        [Required]
        public double Price { get; set; }

        [Display(Name = "Recommendations")]
        [Required]
        public string Recommendations { get; set; }

    }
}
