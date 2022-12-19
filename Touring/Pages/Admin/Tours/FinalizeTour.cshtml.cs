using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Touring.DataAccess.Repository.IRepository;
using Touring.Models;
using Touring.Models.ViewModels;
using Touring.Utility;

namespace Touring.Pages.Admin.Tours
{
    public class FinalizeTourModel : PageModel
    {
        private readonly IUnitOfWork _unitOfWork;

        public FinalizeTourModel(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        [BindProperty]
        public CreateTourVM createTourObj { get; set; }
        public void OnGet(int tourId)
        {
            createTourObj = new CreateTourVM
            {
                TourHeader = _unitOfWork.TourHeader.GetFirstOrDefault(x => x.Id == tourId),
                TourDetails = _unitOfWork.TourDetails.GetAll(x => x.TourHeaderId == tourId).OrderBy(x => x.StartTime).ToList(),
            };

            createTourObj.TourHeader.BookingStart = createTourObj.TourHeader.StartDate - TimeSpan.FromDays(30);
            createTourObj.TourHeader.BookingEnd = createTourObj.TourHeader.StartDate - TimeSpan.FromDays(5);

            foreach (var item in createTourObj.TourDetails)
            {
                if(item.ActivityId != null)
                {
                    item.Activity = _unitOfWork.Activity.GetFirstOrDefault(x => x.Id == item.ActivityId);
                }
                if(item.AccommodationId != null)
                {
                    item.Accommodation = _unitOfWork.Accommodation.GetFirstOrDefault(x => x.Id == item.AccommodationId);
                }
                if(item.TripId != null)
                {
                    item.Trip = _unitOfWork.Trip.GetFirstOrDefault(x => x.Id == item.TripId);
                }
                if(item.MealId != null)
                {
                    item.Meal = _unitOfWork.Meal.GetFirstOrDefault(x => x.Id == item.MealId);
                }


            }
        }

        public IActionResult OnPostRemove(int detailId)
        {
                var detail = _unitOfWork.TourDetails.GetFirstOrDefault(x => x.Id == detailId);
                var tourId = detail.TourHeaderId;
                _unitOfWork.TourDetails.Remove(detail);
                _unitOfWork.Save();
                return RedirectToPage(new { tourId = tourId });
        }

        public IActionResult OnPost()
        {
            var details = _unitOfWork.TourDetails.GetAll(x => x.TourHeaderId == createTourObj.TourHeader.Id);

            foreach (var detail in details)
            {
                createTourObj.TourHeader.CalculatedCosts += detail.Price;
            }

            createTourObj.TourHeader.BookingAllowed = true;
            createTourObj.TourHeader.BookingStatus = SD.TourStatusBooking;
            _unitOfWork.TourHeader.Update(createTourObj.TourHeader);
            _unitOfWork.Save();

            return RedirectToPage("Index");
        }
    }
}
