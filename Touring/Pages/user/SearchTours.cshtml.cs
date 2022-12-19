using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Touring.DataAccess.Repository.IRepository;

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
        public string originCountry { get; set; }

        [BindProperty]
        public string destinationCountry { get; set; }
        public void OnGet(string from, string to)
        {
            if(from != null && from != "")
            {
                originCountry = from;
            }

            if(to != null && to != "")
            {
                destinationCountry = to;
            }
        }
    }
}
