using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
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
        public CreateTourDetailsModel(IUnitOfWork unitOfWork, RoleManager<ApplicationRoles> roleManager, UserManager<ApplicationUser> userManager)
        {
            _unitOfWork = unitOfWork;
            _roleManager = roleManager;
            _userManager = userManager;
        }

        public IEnumerable<SelectListItem> TourGuids { get; set; }

        [BindProperty]
        public CreateTourVM createTourObj { get; set; }
        public void OnGet(int tourId)
        {
            createTourObj = new CreateTourVM
            {
                TourHeader = _unitOfWork.TourHeader.GetFirstOrDefault(x => x.Id == tourId),
                TourDetails = _unitOfWork.TourDetails.GetAll(x => x.TourHeaderId == tourId).ToList(),
                TourDetail = new TourDetails()
            };

            TourGuids = _unitOfWork.ApplicationUser.GetUsersForDropDown(_userManager,_roleManager,SD.RoleTourGuide);

        }

        public IActionResult OnPostContinue()
        {
            if (ModelState.IsValid)
            {

                _unitOfWork.TourDetails.Add(createTourObj.TourDetail);
                _unitOfWork.Save();
            }
            else{
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

        public void OnPostFinalize()
        {

        }

    }
}
