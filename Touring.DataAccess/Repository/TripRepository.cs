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

        public IEnumerable<SelectListItem> ListForDropDown(int tourId)
        {
            TourHeader tour = _context.TourHeader.FirstOrDefault(x => x.Id == tourId);
            string tourCountries = null;
            if(tour.DestinationCountries != null)
            {
                tourCountries = tour.DestinationCountries;
            }

            if(tour.OriginCountry != null)
            {
                if(tourCountries != null)
                {
                    tourCountries += ",";
                }
                tourCountries += tour.OriginCountry;
            }

            String tourCities = null;
            if (tour.DestinationCities != null)
            {
                tourCities = tour.DestinationCities;
            }

            if (tour.OriginCity != null)
            {
                if (tourCities != null)
                {
                    tourCities += ",";
                }
                tourCities += tour.OriginCity;
            }

            List<Trip> query = new List<Trip>();
            List<Trip> finalQuery = new List<Trip>();
            
            if (tourCountries != null)
            {
                var countries = tourCountries.Split(',');
                foreach (var country in countries)
                {
                    var result = _context.Trip.Where(x => x.DestinationCountry == country || x.OriginCountry == country).ToList();
                    query.AddRange(result);
                }

            }
            else
            {
                query = _context.Trip.ToList();
            }
            query = query.Distinct().ToList();
            if (tourCities != null)
            {
                var citites = tourCities.Split(',');
                foreach (var city in citites)
                {
                    var result = query.Where(x => x.DestinationCity == city || x.OriginCity == city).ToList();
                    finalQuery.AddRange(result);
                }
            }
            else
            {
                finalQuery = query;
            }
            finalQuery = finalQuery.Distinct().ToList();
            finalQuery = finalQuery.Where(x => x.DepartureTime > tour.StartDate && x.ArrivalTime < tour.EndDate).ToList();
            return finalQuery.Select(x => new SelectListItem
            {
                Text = x.Vehicle + "(" + x.OriginCity + "-" + x.DestinationCity + ")" + x.DepartureTime.ToShortDateString() + " " + x.DepartureTime.ToShortTimeString(),
                Value = Convert.ToString(x.Id)
            });
        }
    }
}
