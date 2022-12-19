using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Touring.Models
{
    public class TourDetails
    {
        public int Id { get; set; }
        public int TourHeaderId { get; set; }
        [ForeignKey("TourHeaderId")]
        public virtual TourHeader TourHeader { get; set; }

        public string Title { get; set; }
        public DateTime StartTime { get; set; }
        public DateTime EndTime { get; set; }

        [NotMapped]
        public DateTime StartDate { get; set; }
        [NotMapped]
        public DateTime EndDate { get; set; }

        public string TourGuideId { get; set; }
        [ForeignKey("TourGuideId")]
        public virtual ApplicationUser ApplicationUser { get; set; }

        public int? ActivityId { get; set; }
        [ForeignKey("ActivityId")]
        public virtual Activity Activity { get; set; }

        public int? TripId { get; set; }
        [ForeignKey("TripId")]
        public virtual Trip Trip { get; set; }

        [Display(Name = "Accommodation")]
        public int? AccommodationId { get; set; }
        [ForeignKey("AccommodationId")]
        public virtual Accommodation Accommodation { get; set; }

        [Display(Name = "Meal")]
        public int? MealId { get; set; }
        [ForeignKey("MealId")]
        public virtual Meal Meal { get; set; }

        public double Price { get; set; }
        public string Recommendations { get; set; }
    }
}
