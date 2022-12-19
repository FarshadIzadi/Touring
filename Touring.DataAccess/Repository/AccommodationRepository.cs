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

        public IEnumerable<SelectListItem> ListForDropDown(int tourId)
        {
            TourHeader tour = _context.TourHeader.FirstOrDefault(x => x.Id == tourId);
            List<Accommodation> query = new List<Accommodation>();
            List<Accommodation> finalQuery = new List<Accommodation>();
            if(tour.DestinationCountries != null)
            {
                var countries = tour.DestinationCountries.Split(',');
                foreach (var country in countries)
                {
                    var result = _context.Accommodation.Where(x => x.Country == country).ToList();
                    query.AddRange(result);
                }

            }
            else
            {
                query = _context.Accommodation.ToList();
            }

            if(tour.DestinationCities != null)
            {
                var citites = tour.DestinationCities.Split(',');
                foreach (var city in citites)
                {
                    var result = query.Where(x => x.City == city).ToList();
                    finalQuery.AddRange(result);
                }
            }
            else
            {
                finalQuery = query;
            }


            return finalQuery.Select(x => new SelectListItem { 
                Text = x.Name + ", " + x.City + " (" + x.Country + ")",
                Value = Convert.ToString(x.Id)
            });
        }
    }
}
