using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
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
        public void OnGet(int? tourId)
        {
            TourHeader = new TourHeader();
            if((tourId ?? 0) != 0)
            {
                TourHeader = _unitOfWork.TourHeader.GetFirstOrDefault(x => x.Id == tourId);   
            }
        }

        public IActionResult OnPost()
        {
            IFormCollection formData = HttpContext.Request.Form;

            for (int i = 0; i < formData.Count; i++)
            {
                var firstname = formData["firstName"][i];
                var secondname = formData["firstName"][i];

            
            
            }



            
            return Page();
        }

    }


}
