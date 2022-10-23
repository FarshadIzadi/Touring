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
    public class TripRepository : Repository<Trip>, ITripRepository
    {
        private readonly ApplicationDbContext _context;
        public TripRepository(ApplicationDbContext context) : base(context)
        {
            _context = context;
        }

        public IEnumerable<SelectListItem> ListForDropDown()
        {
            return _context.Trip.Select(x => new SelectListItem { 
                Text = x.Vehicle + " " + x.OriginCity + " (" + x.OriginCountry + ") " + x.DepartureTime + " " + x.DestinationCity,
                Value = Convert.ToString(x.Id)
            });
        }
    }
}
