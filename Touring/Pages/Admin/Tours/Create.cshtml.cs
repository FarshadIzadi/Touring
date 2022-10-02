using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Touring.DataAccess.Repository.IRepository;
using Touring.Models;
using Touring.Utility;

namespace Touring.Pages.Admin.Tours
{
    [Authorize(Roles = SD.RoleManager + "," + SD.RoleTourManager)]
    public class CreateModel : PageModel
    {
        private readonly IUnitOfWork _unitOfWork;

        public CreateModel(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        [BindProperty]
        public TourHeader TourHeaderObj { get; set; }
        public void OnGet()
        {
            TourHeaderObj = new TourHeader();
        }

        public IActionResult OnPost()
        {
            if (ModelState.IsValid)
            {
                var claimIdentity = (ClaimsIdentity)this.User.Identity;
                var claim = claimIdentity.FindFirst(ClaimTypes.NameIdentifier);

                TourHeaderObj.ManagerId = claim.Value;
                TourHeaderObj.BookingStatus = SD.TourStatusCreating;
                _unitOfWork.TourHeader.Add(TourHeaderObj);
                _unitOfWork.Save();

                return RedirectToPage("CreateTourDetails", new { tourId = TourHeaderObj.Id });
            }
            else
            {
                return Page();
            }

            return Page();
        }
    }
}
