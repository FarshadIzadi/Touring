using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Touring.DataAccess.Repository.IRepository;
using Touring.Utility;

namespace Touring.Pages.user
{
    public class IndexModel : PageModel
    {
        private readonly IUnitOfWork _unitOfWork;

        public IndexModel(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public SelectList originCountries { get; set; }
        public SelectList destinationCountries { get; set; }
        
        [BindProperty]
        public string originCountry { get; set; }
        [BindProperty]
        public string destinationCountry { get; set; }

        public void OnGet()
        {
            IEnumerable<SelectListItem> oCountries = _unitOfWork.TourHeader.GetAll(x => x.BookingStatus == SD.TourStatusBooking).Select(s => new SelectListItem { 
                Text = s.OriginCountry,
                Value = s.OriginCountry
            });

            originCountries = new SelectList(oCountries.Distinct(), "Value", "Text");

            IEnumerable<SelectListItem> dCountries = _unitOfWork.TourHeader.GetAll(x => x.BookingStatus == SD.TourStatusBooking).Select(s => new SelectListItem
            {
                Text = s.DestinationCountries,
                Value = s.DestinationCountries
            });

            List<SelectListItem> seperatedCountries = new List<SelectListItem>();

            foreach (var item in dCountries.Distinct())
            {
                var entries = item.Text.Split(new char[] { ',' }, StringSplitOptions.RemoveEmptyEntries);
                foreach (var entry in entries)
                {
                    seperatedCountries.Add(new SelectListItem(entry, entry));
                }
            
            }
            destinationCountries = new SelectList(seperatedCountries, "Value", "Text");
        }

        public IActionResult OnPost()
        {
            return RedirectToPage("SearchTours", new { from = originCountry, to = destinationCountry });
        }
    }
}
