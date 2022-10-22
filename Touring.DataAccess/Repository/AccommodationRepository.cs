using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Touring.DataAccess.Repository.IRepository;
using Touring.Models;

namespace Touring.DataAccess.Repository
{
    public class AccommodationRepository : Repository<Accommodation>, IAccommodationRepository
    {
        private readonly ApplicationDbContext _context;
        public AccommodationRepository(ApplicationDbContext context) : base(context)
        {
            _context = context;
        }

        public IEnumerable<SelectListItem> ListForDropDown()
        {
            return _context.Accommodation.Select(x => new SelectListItem { 
                Text = x.Name,
                Value = Convert.ToString(x.Id)
            });
        }
    }
}
