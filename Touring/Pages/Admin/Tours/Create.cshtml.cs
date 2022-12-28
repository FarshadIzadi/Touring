using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Security.Claims;
using System.Text.Json;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Touring.DataAccess.Repository.IRepository;
using Touring.Models;
using Touring.Utility;

namespace Touring.Pages.Admin.Tours
{
    [Authorize(Roles = SD.RoleManager + "," + SD.RoleTourManager)]
    public class CreateModel : PageModel
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IWebHostEnvironment _webHostEnvironment;
        public CreateModel(IUnitOfWork unitOfWork, IWebHostEnvironment webHostEnvironment)
        {
            _unitOfWork = unitOfWork;
            _webHostEnvironment = webHostEnvironment;
        }

        public SelectList countries { get; set; }
        [BindProperty]
        public TourHeader TourHeaderObj { get; set; }
        public void OnGet()
        {
            TourHeaderObj = new TourHeader();
            TourHeaderObj.StartDate = DateTime.Now + TimeSpan.FromDays(7);
            TourHeaderObj.EndDate = DateTime.Now + TimeSpan.FromDays(14);

            var rootPath = _webHostEnvironment.WebRootPath;

            var fullFilePath = Path.Combine(rootPath, @"files\countries.min.json");
            var fileData = System.IO.File.ReadAllText(fullFilePath);

            JsonDocument document = JsonDocument.Parse(fileData);
            countries = new SelectList(document.RootElement.EnumerateObject(), "Name", "Name");


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

        }
    }
}
