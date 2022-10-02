using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Touring.Models
{
    public class TourHeader
    {
        public int Id { get; set; }
        public string ManagerId { get; set; }
        [ForeignKey("ManagerId")]
        public virtual ApplicationUser ApplicationUser { get; set; }

        [Required]
        [Display(Name ="Tour Title")]
        public string TourTitle { get; set; }
        [Required]
        [Range(1,1000,ErrorMessage = "Tour Capacity Out of Range")]
        public int TourCapacity { get; set; }
        public string BookingStatus { get; set; }
        public double CalculatedCosts { get; set; }  // the sum of all activities trips and accommodation
        public double ExtraCosts { get; set; }       // expenses payed by agency for each person like visa expenses
        public double BenefitPerPerson { get; set; } //desired profit for the agency for each tourist
        public string Description { get; set; }
        
        [Required]
        public string OriginCountry { get; set; }

        [Required]
        public string OriginCity{ get; set; }

        [Required]
        public string DestinationCountries { get; set; }

        [Required]
        public string DestinationCities { get; set; }

        public TourHeader()
        {
            TourCapacity = 10;
        }
    }
}
