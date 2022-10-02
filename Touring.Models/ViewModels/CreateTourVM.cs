using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Touring.Models.ViewModels
{
    public class CreateTourVM
    {
        public TourHeader TourHeader { get; set; }
        public TourDetails TourDetail { get; set; }
        public List<TourDetails> TourDetails { get; set; }
    }
}
