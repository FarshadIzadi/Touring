using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Touring.DataAccess.Repository.IRepository;
using Touring.Models;
using Touring.Utility;

namespace Touring.Pages.user
{
    [Authorize]
    public class ConfirmAndPayModel : PageModel
    {

        private readonly IUnitOfWork _unitOfWork;

        public ConfirmAndPayModel(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }


        public TourHeader TourHeader { get; set; }
        public IEnumerable<PassengerGroups> Passengers { get; set; }
        public IEnumerable<TourDetails> tourDetails { get; set; }
        [BindProperty]
        public TourBook bookedTour { get; set; }
        [BindProperty]
        public int TourId { get; set; }
        public List<string> Errors { get; set; }

        public void OnGet(int? bookingId)
        {
            if ((bookingId ?? 0) != 0)
            {
                bookingId = (Int32)bookingId;
                bookedTour = _unitOfWork.TourBook.GetFirstOrDefault(x => x.Id == bookingId);
                TourHeader = _unitOfWork.TourHeader.GetFirstOrDefault(x => x.Id == bookedTour.TourHeaderId);
                ClaimsIdentity claimsIdentity = (ClaimsIdentity)this.User.Identity;
                string userId = claimsIdentity.FindFirst(x => x.Type == ClaimTypes.NameIdentifier).Value;

                tourDetails = _unitOfWork.TourDetails.GetAll(x => x.TourHeaderId == bookedTour.TourHeaderId);
                Passengers = _unitOfWork.PassengerGroups.GetAll(x => x.TourBookId == bookingId && x.UserId == userId);

                bookedTour.TotalPrice = 0;
                foreach (var tourDetail in tourDetails)
                {
                    bookedTour.TotalPrice = bookedTour.TotalPrice + (decimal)(tourDetail.Price * Passengers.Count());
                }
                bookedTour.TotalPrice += TourHeader.ExtraCosts * Passengers.Count();


            }
            else
            {
                Errors.Add("Something went wrong");
            }
        }


        public IActionResult OnPost()
        {
            return Page();
        }

        public IActionResult OnPostApplyDiscount(discountModel discount)
        {


            bookedTour = _unitOfWork.TourBook.GetFirstOrDefault(x => x.Id == discount.bookingId);

            TourHeader = _unitOfWork.TourHeader.GetFirstOrDefault(x => x.Id == bookedTour.TourHeaderId);
            ClaimsIdentity claimsIdentity = (ClaimsIdentity)this.User.Identity;
            string userId = claimsIdentity.FindFirst(x => x.Type == ClaimTypes.NameIdentifier).Value;

            tourDetails = _unitOfWork.TourDetails.GetAll(x => x.TourHeaderId == bookedTour.TourHeaderId);
            Passengers = _unitOfWork.PassengerGroups.GetAll(x => x.TourBookId == discount.bookingId && x.UserId == userId);

            bookedTour.TotalPrice = 0;
            foreach (var tourDetail in tourDetails)
            {
                bookedTour.TotalPrice = bookedTour.TotalPrice + (decimal)(tourDetail.Price * Passengers.Count());
            }
            bookedTour.TotalPrice += TourHeader.ExtraCosts * Passengers.Count();

            // Calculate discount
            var discountObj = _unitOfWork.Discount.GetFirstOrDefault(x => x.DiscountCode == discount.discountCode);
            if (discountObj != null)
            {

                if (discountObj.DiscountPercentage != null)
                {
                    bookedTour.discountAmmount = bookedTour.TotalPrice * (decimal)(discountObj.DiscountPercentage) / 100;
                }
                else
                {
                    bookedTour.discountAmmount = bookedTour.TotalPrice - (discountObj.DiscountAmount ?? 0);
                }
                bookedTour.DiscountId = discountObj.Id;
                _unitOfWork.Save();
            }//if(discountOjb != null)




            return Page();
        }


    }

    public class discountModel
    {
        [BindProperty]
        public string discountCode { get; set; }

        [BindProperty]
        public int bookingId { get; set; }

    }
}
