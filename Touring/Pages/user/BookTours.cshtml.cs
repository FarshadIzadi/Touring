using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Touring.DataAccess.Repository.IRepository;
using Touring.Models;
using Touring.Models.ViewModels;
using Touring.Utility;

namespace Touring.Pages.user
{
    [Authorize]
    public class BookToursModel : PageModel
    {
        private readonly IUnitOfWork _unitOfWork;

        public BookToursModel(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }


        public TourHeader TourHeader { get; set; }
        public IEnumerable<PassengerGroups> Passengers { get; set; }
        [BindProperty]
        public int tourBookId { get; set; }
        [BindProperty]
        public int TourId { get; set; }
        public void OnGet(int? tourId)
        {
            if (tourId != null)
            {
                TourId = (Int32)tourId;
            }
            tourBookId = 0;
            TourHeader = new TourHeader();
            if ((tourId ?? 0) != 0)
            {
                TourHeader = _unitOfWork.TourHeader.GetFirstOrDefault(x => x.Id == tourId);

            }

            ClaimsPrincipal principals = HttpContext.User as ClaimsPrincipal;
            var userId = "";
            if (principals != null)
            {
                var claims = principals.Claims;
                userId = claims.First(x => x.Type ==  ClaimTypes.NameIdentifier).Value;
            }

            Passengers = _unitOfWork.PassengerGroups.GetAll(filter:x => x.UserId == userId,includeProperties:"TourBook");
            Passengers = Passengers.Where(x => x.TourBook.TourHeaderId == tourId);
            if (Passengers != null && Passengers.Count() > 0)
            {
                tourBookId = Passengers.First().TourBookId;
            }

        }

        public IActionResult OnPost()
        {
            if (ModelState.IsValid)
            {
                ClaimsPrincipal principal = HttpContext.User as ClaimsPrincipal;
                string UserId = null;
                if (principal != null)
                {
                    var claims = principal.Claims;
                    UserId = claims.First(x => x.Type == ClaimTypes.NameIdentifier).Value;
                }


                TourHeader tourHeader = _unitOfWork.TourHeader.GetFirstOrDefault(x => x.Id == TourId);

                TourBook tourBook = _unitOfWork.TourBook.GetFirstOrDefault(x => x.TourHeaderId == TourId && x.UserId == UserId);
                if (!(tourBook != null && tourBook.Id > 0))
                {
                    tourBook = new TourBook
                    {
                        UserId = UserId,
                        TourHeaderId = TourId,
                        Status = SD.BookingStatusPending
                    };
                    _unitOfWork.TourBook.Add(tourBook);
                    _unitOfWork.Save();
                }

                IFormCollection formData = HttpContext.Request.Form;
                var g = Convert.ToInt32(formData["passengerCount"][0]);
                for (int i = 0; i < Convert.ToInt32(formData["passengerCount"][0]); i++)
                {
                    var pGId = Convert.ToInt32(formData["passengerGroupId"][i]);
                    PassengerGroups pGroup = _unitOfWork.PassengerGroups?.GetFirstOrDefault(x => x.Id == pGId);

                    if (pGroup != null)
                    {
                        pGroup.FristName = formData["firstName"][i];
                        pGroup.LastName = formData["lastName"][i];
                        pGroup.UserId = UserId;
                        pGroup.TourBookId = tourBook.Id;
                        pGroup.Age = Convert.ToInt32(formData["age"][i]);
                        pGroup.Gender = formData["gender"][i];
                        pGroup.PassportStatus = tourHeader.PassportRequirement;
                        pGroup.PassportExpDate = Convert.ToDateTime(formData["passExpDate"][i]);
                        pGroup.VisaStatus = tourHeader.VisaRequirement;
                        pGroup.Vaccinetatus = formData["vaccine"][i];
                        _unitOfWork.PassengerGroups.Update(pGroup);
                    }
                    else
                    {

                        pGroup = new PassengerGroups
                        {
                            FristName = formData["firstName"][i],
                            LastName = formData["lastName"][i],
                            UserId = UserId,
                            TourBookId = tourBook.Id,
                            Age = Convert.ToInt32(formData["age"][i]),
                            Gender = formData["gender"][i],
                            PassportStatus = tourHeader.PassportRequirement,
                            PassportExpDate = Convert.ToDateTime(formData["passExpDate"][i]),
                            VisaStatus = tourHeader.VisaRequirement,
                            Vaccinetatus = formData["vaccine"][i]
                        };
                        _unitOfWork.PassengerGroups.Add(pGroup);
                    }
                }
                _unitOfWork.Save();
                return RedirectToPage("ConfirmAndPay", new { bookingId = tourBook.Id });
            }
            else
            {
                var t = TourId;
                return Page();
            }
        }

    }


}
