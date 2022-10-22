using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Touring.Models
{
    public class Accommodation
    {
        public int Id { get; set; }
        
        [Display(Name="Accommodation Title")]
        [Required(ErrorMessage = "Required Field")]
        public string Name { get; set; }
        

        [Display(Name="Phone Number")]
        [Required(ErrorMessage = "Required Field")]
        public string PhoneNumber { get; set; }

        [Display(Name="Contact Name")]
        [Required(ErrorMessage = "Required Field")]
        public string ContactName { get; set; }

        [Display(Name="Country")]
        [Required(ErrorMessage = "Required Field")]
        public string Country { get; set; }

        [Display(Name = "City")]
        [Required(ErrorMessage = "Required Field")]
        public string City { get; set; }


        [Display(Name = "Address")]
        [Required(ErrorMessage = "Required Field")]
        public string Address { get; set; }

        public int Stars { get; set; }
        public string RoomSize { get; set; }

        [Display(Name= "Price")]
        [Required]
        public double Price { get; set; }
        public string Description { get; set; }
    }
}
