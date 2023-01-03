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
        [ForeignKey("TourId")]
        public TourHeader TourHeader { get; set; }

        public string UserId { get; set; }
        [ForeignKey("UserId")]
        public ApplicationUser ApplicationUser { get; set; }

        public decimal TotalPrice { get; set; }
        [Range(0,100,ErrorMessage = "Discount must be between 0% to 100%")]
        public int Discount { get; set; }
        [NotMapped]
        public virtual ICollection<Payments> Payments { get; set; }

        public string Status { get; set; }

        public TourBook()
        {
            Discount = 0;
        }

    
    }
}
