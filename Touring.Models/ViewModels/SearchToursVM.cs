using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Touring.Models.ViewModels
{
    public class SearchToursVM
    {
        public TourHeader TourHeader { get; set; }
        public List<TourHeader> TourHeaders { get; set; }
        public SelectList originCountries { get; set; }
        public SelectList destinationCountries { get; set; }
    }
}
