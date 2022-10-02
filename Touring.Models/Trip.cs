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

        [Display(Name = "Flight Number")]
        [Required]
        public string FlightNumber { get; set; }

        [Display(Name = "Bus Number")]
        [Required]
        public string BusNumber { get; set; }

        [Display(Name = "Origin")]
        [Required]
        public string Origin { get; set; }

        [Display(Name = "Destination")]
        [Required]
        public string Destination { get; set; }

        [Display(Name = "Recommendations")]
        [Required]
        public string Recommendations { get; set; }

    }
}
