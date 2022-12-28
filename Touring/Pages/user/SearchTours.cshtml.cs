using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Touring.DataAccess.Repository.IRepository;
using Touring.Models;
using Touring.Models.ViewModels;
using Touring.Utility;

namespace Touring.Pages.user
{
    public class SearchToursModel : PageModel
    {
        private readonly IUnitOfWork _unitOfWork;

        public SearchToursModel(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        [BindProperty]
        public SearchToursVM searchObj { get; set; }
        public void OnGet(string from, string to)
        {

            searchObj = new SearchToursVM() {
                TourHeader = new TourHeader(),
                TourHeaders = new List<TourHeader>()
            };
            searchObj.TourHeader.StartDate = _unitOfWork.TourHeader.GetAll(x => x.BookingStatus == SD.TourStatusBooking).OrderBy(d => d.StartDate).FirstOrDefault().StartDate;
            searchObj.TourHeader.EndDate = _unitOfWork.TourHeader.GetAll(x => x.BookingStatus == SD.TourStatusBooking).OrderByDescending(d => d.StartDate).FirstOrDefault().EndDate;

            IEnumerable<SelectListItem> oCountries = _unitOfWork.TourHeader.GetAll(x => x.BookingStatus == SD.TourStatusBooking).Select(s => new SelectListItem
            {
                Text = s.OriginCountry,
                Value = s.OriginCountry
            });
            
            searchObj.originCountries = new SelectList(oCountries.Distinct(new EqualSelectLists()), "Value", "Text") ;
            if ((from ?? "") != "")
            {
                foreach (var item in searchObj.originCountries)
                {
                    if(item.Value == from)
                    {
                        item.Selected = true;
                    }
                }
            }

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

            searchObj.destinationCountries = new SelectList(seperatedCountries.Distinct(new EqualSelectLists()), "Value", "Text");
            if ((to ?? "") != "")
            {
                foreach (var item in searchObj.destinationCountries)
                {
                    if (item.Value == to)
                    {
                        item.Selected = true;
                    }
                }
            }

            searchObj.TourHeaders = _unitOfWork.TourHeader.GetAll(x => x.StartDate >= (searchObj.TourHeader.StartDate - TimeSpan.FromDays(1)) && x.EndDate <= (searchObj.TourHeader.EndDate + TimeSpan.FromDays(1))).ToList();
            if ((from ?? "") != "")
            {
                searchObj.TourHeaders = searchObj.TourHeaders.Where(x => x.OriginCountry == from).ToList();
            }

            if ((to ?? "") != "")
            {
                searchObj.TourHeaders = searchObj.TourHeaders.Where(x => x.DestinationCountries.Contains(to)).ToList();
            }

            foreach (var tour in searchObj.TourHeaders)
            {
                tour.TourDetails = _unitOfWork.TourDetails.GetAll(filter: x => (x.AccommodationId ?? 0) != 0 && x.TourHeaderId == tour.Id, includeProperties: "Accommodation");
            }





        }

        public IActionResult OnPost()
        {
            searchObj.TourHeaders = _unitOfWork.TourHeader.GetAll(x => x.StartDate >= (searchObj.TourHeader.StartDate - TimeSpan.FromDays(1)) && x.EndDate <= (searchObj.TourHeader.EndDate + TimeSpan.FromDays(1))).ToList();

            IEnumerable<SelectListItem> oCountries = _unitOfWork.TourHeader.GetAll(x => x.BookingStatus == SD.TourStatusBooking).Select(s => new SelectListItem
            {
                Text = s.OriginCountry,
                Value = s.OriginCountry
            });

            searchObj.originCountries = new SelectList(oCountries.Distinct(new EqualSelectLists()), "Value", "Text");
            if ((searchObj.TourHeader.OriginCountry ?? "") != "")
            {
                foreach (var item in searchObj.originCountries)
                {
                    if (item.Value == searchObj.TourHeader.OriginCountry)
                    {
                        item.Selected = true;
                    }
                }
            }

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

            searchObj.destinationCountries = new SelectList(seperatedCountries.Distinct(new EqualSelectLists()), "Value", "Text");
            if ((searchObj.TourHeader.DestinationCountries ?? "") != "")
            {
                foreach (var item in searchObj.destinationCountries)
                {
                    if (item.Value == searchObj.TourHeader.DestinationCountries)
                    {
                        item.Selected = true;
                    }
                }
            }

            if((searchObj.TourHeader.OriginCountry ?? "") != "")
            {
                searchObj.TourHeaders = searchObj.TourHeaders.Where(x => x.OriginCountry == searchObj.TourHeader.OriginCountry).ToList();
            }

            if((searchObj.TourHeader.DestinationCountries ?? "") != "")
            {
                searchObj.TourHeaders = searchObj.TourHeaders.Where(x => x.DestinationCountries.Contains(searchObj.TourHeader.DestinationCountries)).ToList();
            }

            if((searchObj.TourHeader.OriginCity ?? "") != "")
            {
                searchObj.TourHeaders = searchObj.TourHeaders.Where(x => x.OriginCity == searchObj.TourHeader.OriginCity).ToList();
            }

            if ((searchObj.TourHeader.DestinationCities ?? "") != "")
            {
                searchObj.TourHeaders = searchObj.TourHeaders.Where(x => x.DestinationCities.Contains(searchObj.TourHeader.DestinationCities)).ToList();
            }

          
            foreach (var tour in searchObj.TourHeaders)
            {
                tour.TourDetails = _unitOfWork.TourDetails.GetAll(filter: x => (x.AccommodationId ?? 0) != 0 && x.TourHeaderId == tour.Id,includeProperties:"Accommodation");
            }



            return Page();
        }
    }

    public class EqualSelectLists : IEqualityComparer<SelectListItem>
    {
        public bool Equals(SelectListItem x, SelectListItem y)
        {
            if (x == null && y == null)
            {
                return true;
            }else if (x == null || y == null)
            {
                return false;
            }

            return x.Value.Equals(y.Value);
        }

        public int GetHashCode(SelectListItem obj)
        {
            if (Object.ReferenceEquals(obj, null)) return 0;

            return obj.Text.GetHashCode() ^ obj.Value.GetHashCode();
        }
    }
}
