using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Touring.Models
{
    public class TourBook
    {
        public int Id { get; set; }

        public int TourHeaderId { get; set; }
        [ForeignKey("TourHeaderId")]
        public virtual TourHeader TourHeader { get; set; }

        public string UserId { get; set; }
        [ForeignKey("UserId")]
        public virtual ApplicationUser ApplicationUser { get; set; }

        public decimal TotalPrice { get; set; }
        public decimal discountAmmount { get; set; }
        public int? DiscountId { get; set; }
        [ForeignKey("DiscountId")]
        public virtual Discounts Discounts { get; set; }

        [NotMapped]
        public virtual ICollection<Payments> Payments { get; set; }
        [NotMapped]
        public virtual ICollection<PassengerGroups> PassengerGroups { get; set; }

        public string Status { get; set; }

    
    }
}
