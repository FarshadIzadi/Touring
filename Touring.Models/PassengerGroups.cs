using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Touring.Models
{
    public class PassengerGroups
    {
        [Key]
        public int Id { get; set; }
        public string UserId { get; set; }

        [ForeignKey("UserId")]
        public ApplicationUser ApplicationUser { get; set; }
        public string FristName { get; set; }
        public string LastName { get; set; }

        [NotMapped]
        public string FullName { get { return FristName + " " + LastName; }}

        public int TourHeaderId { get; set; }
        [ForeignKey("TourHeaderId")]
        public TourHeader TourHeader { get; set; }

        public string Gender { get; set; }
        public int Age { get; set; }
        public string PassportStatus { get; set; }
        public string VisaStatus { get; set; }
        public string Vaccinetatus { get; set; }
        public DateTime PassportExpDate { get; set; }
        public DateTime VisaExpDate { get; set; }
    }
}
