using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Touring.Models
{
    public class Activity
    {
        public int Id { get; set; }
     
        [Required]
        [Display(Name="Activity Name")]
        public string Name { get; set; }
        
        [Required]
        [Display(Name="Country")]
        public string Country { get; set; }
        
        [Required]
        [Display(Name="City")]
        public string City { get; set; }
        
        [Required]
        [Display(Name="Address")]
        public string Address { get; set; }
        
        [Required]
        [Display(Name="Recommendations")]
        public string Recommendations { get; set; }
        
        [Required]
        [Display(Name="Price")]
        [Range(0,int.MaxValue,ErrorMessage = "Price can't be less than $ 0")]
        public double price { get; set; }
        
        [Required]
        [Display(Name="Description")]
        public string Description { get; set; }
    }
}
