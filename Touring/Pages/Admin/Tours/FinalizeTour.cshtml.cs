using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Touring.DataAccess.Repository.IRepository;
using Touring.Models;
using Touring.Models.ViewModels;

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
                TourDetails = _unitOfWork.TourDetails.GetAll(x => x.TourHeaderId == tourId).ToList(),
                TourDetail = new TourDetails()
            };
        }
    }
}
