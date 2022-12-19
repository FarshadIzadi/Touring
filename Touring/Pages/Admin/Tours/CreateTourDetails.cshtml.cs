using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text.Json;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Newtonsoft.Json;
using Touring.DataAccess.Repository.IRepository;
using Touring.Models;
using Touring.Models.ViewModels;
using Touring.Utility;

namespace Touring.Pages.Admin.Tours
{
    [Authorize(Roles = SD.RoleManager + "," + SD.RoleTourManager)]
    public class CreateTourDetailsModel : PageModel
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly RoleManager<ApplicationRoles> _roleManager;
        private readonly UserManager<ApplicationUser> _userManager;
        public CreateTourDetailsModel(IUnitOfWork unitOfWork, RoleManager<ApplicationRoles> roleManager, UserManager<ApplicationUser> userManager, IWebHostEnvironment webHostEnvironment)
        {
            _unitOfWork = unitOfWork;
            _roleManager = roleManager;
            _userManager = userManager;
        }

        public IEnumerable<SelectListItem> TourGuids { get; set; }
        public IEnumerable<SelectListItem> Trips { get; set; }
        public IEnumerable<SelectListItem> Accommodations { get; set; }
        public IEnumerable<SelectListItem> Meals { get; set; }
        public IEnumerable<SelectListItem> Activities { get; set; }
        public IEnumerable<string> Errors { get; set; }
        [BindProperty]
        public CreateTourVM createTourObj { get; set; }
        public void OnGet(int tourId)
        {
            createTourObj = new CreateTourVM
            {
                TourHeader = _unitOfWork.TourHeader.GetFirstOrDefault(x => x.Id == tourId),
                TourDetails = _unitOfWork.TourDetails.GetAll(x => x.TourHeaderId == tourId, includeProperties: "Activity,Accommodation,Trip").ToList(),
                
                
                TourDetail = new TourDetails
                {
                    StartDate = DateTime.Now,
                    StartTime = DateTime.Now,
                    EndDate = DateTime.Now,
                    EndTime = DateTime.Now
                }
            };

            createTourObj.TourHeader.CalculatedCosts = 0;
            foreach (var detail in createTourObj.TourDetails)
            {
                createTourObj.TourHeader.CalculatedCosts += detail.Price;
            }

            TourGuids = _unitOfWork.ApplicationUser.GetUsersForDropDown(_userManager, _roleManager, SD.RoleTourGuide);

            Trips = _unitOfWork.Trip.ListForDropDown(createTourObj.TourHeader.Id);
            Accommodations = _unitOfWork.Accommodation.ListForDropDown(createTourObj.TourHeader.Id);
            Activities = _unitOfWork.Activity.ListForDropDown(createTourObj.TourHeader.Id);
            Meals = _unitOfWork.Meal.ListForDropDown();
            Errors = null;
        }

        public IActionResult OnPostContinue()
        {
            var timeConflicts = _unitOfWork.TourDetails.GetTimeConflicts(createTourObj.TourHeader.Id,createTourObj.TourDetail);
            if (ModelState.IsValid && timeConflicts.Count() < 1)
            {

                createTourObj.TourDetail.StartTime =   Convert.ToDateTime(createTourObj.TourDetail.StartDate.ToShortDateString() 
                                                                + " " + createTourObj.TourDetail.StartTime.ToShortTimeString());
                createTourObj.TourDetail.EndTime = Convert.ToDateTime(createTourObj.TourDetail.EndDate.ToShortDateString() 
                                                              + " " + createTourObj.TourDetail.EndTime.ToShortTimeString());
                createTourObj.TourDetail.TourHeaderId = createTourObj.TourHeader.Id;

                _unitOfWork.TourDetails.Add(createTourObj.TourDetail);
                _unitOfWork.Save();
            }
            else{

                createTourObj = new CreateTourVM
                {
                    TourHeader = _unitOfWork.TourHeader.GetFirstOrDefault(x => x.Id == createTourObj.TourHeader.Id),
                    TourDetails = _unitOfWork.TourDetails.GetAll(x => x.TourHeaderId == createTourObj.TourHeader.Id, includeProperties: "Activity,Accommodation,Trip").ToList(),
                    TourDetail = new TourDetails
                    {
                        StartDate = DateTime.Now,
                        StartTime = DateTime.Now,
                        EndDate = DateTime.Now,
                        EndTime = DateTime.Now
                    }
                };

                createTourObj.TourHeader.CalculatedCosts = 0;
                foreach (var detail in createTourObj.TourDetails)
                {
                    createTourObj.TourHeader.CalculatedCosts += detail.Price;
                }

                TourGuids = _unitOfWork.ApplicationUser.GetUsersForDropDown(_userManager, _roleManager, SD.RoleTourGuide);

                Trips = _unitOfWork.Trip.ListForDropDown(createTourObj.TourHeader.Id);
                Accommodations = _unitOfWork.Accommodation.ListForDropDown(createTourObj.TourHeader.Id);
                Activities = _unitOfWork.Activity.ListForDropDown(createTourObj.TourHeader.Id);
                Meals = _unitOfWork.Meal.ListForDropDown();
                Errors = timeConflicts;
                return Page();
            }
            var tourId = createTourObj.TourHeader.Id;
            createTourObj = new CreateTourVM
            {
                TourHeader = _unitOfWork.TourHeader.GetFirstOrDefault(x => x.Id == tourId),
                TourDetails = _unitOfWork.TourDetails.GetAll(x => x.TourHeaderId == tourId).ToList(),
                TourDetail = new TourDetails()
            };
            return RedirectToPage("CreateTourDetails", new { tourId = tourId });
        }



    }
}
