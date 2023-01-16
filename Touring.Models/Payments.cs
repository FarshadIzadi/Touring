using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Touring.Models
{
    public class Payments
    {
        public int Id { get; set; }
        public int? TourBookId { get; set; }
        [ForeignKey("TourBookId")]
        public virtual TourBook TourBook { get; set; }
        public string UserId { get; set; }
        [ForeignKey("UserId")]
        public virtual ApplicationUser ApplicationUser { get; set; }
        public decimal MoneyIn { get; set; }
        public decimal MoneyOut { get; set; }
        public string Description { get; set; }
    }
}
