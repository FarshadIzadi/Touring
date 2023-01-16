using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Touring.Models
{
    public class Discounts
    {
        [Key]
        public int Id { get; set; }

        [Required(ErrorMessage = "This field is Required")]
        [Display(Name = "Title")]
        public string DiscountTitle { get; set; }

        [Required(ErrorMessage = "This field is Required")]
        [Display(Name = "Dicount Code")]
        public string DiscountCode { get; set; }

        [Required(ErrorMessage = "This field is Required")]
        [Display(Name = "Start Date")]
        public DateTime ValidFrom { get; set; }

        [Required(ErrorMessage = "This field is Required")]
        [Display(Name = "End Date")]
        public DateTime ValidUntill { get; set; }
        [Display(Name = "Discount Percentage")]
        [Range(0,100,ErrorMessage = "Out of Range")]
        public int? DiscountPercentage { get; set; }
        [Display(Name = "Discount Amount")]
        public decimal? DiscountAmount { get; set; }

        [NotMapped]
        public ICollection<TourBook> TourBooks { get; set; }
    }
}
