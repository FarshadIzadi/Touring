using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Touring.Models
{
    public class DiscountAssignment
    {
        public int Id { get; set; }
        public string UserId { get; set; }
        [ForeignKey("UserId")]
        public virtual ApplicationUser ApplicationUser { get; set; }

        public int DiscountId { get; set; }
        [ForeignKey("DiscountId")]
        public virtual Discounts Discount { get; set; }

        public bool applied { get; set; }

        public DiscountAssignment()
        {
            applied = false;
        }
    }
    
}
