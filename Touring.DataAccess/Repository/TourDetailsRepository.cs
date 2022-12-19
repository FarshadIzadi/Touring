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
    public class TourDetailsRepository : Repository<TourDetails>, ITourDetailsRepository
    {
        private readonly ApplicationDbContext _context;
        public TourDetailsRepository(ApplicationDbContext context) : base(context)
        {
            _context = context;
        }

        public IEnumerable<string> GetTimeConflicts(int tourId)
        {
            var tour = _context.TourHeader.FirstOrDefault(x => x.Id == tourId);
            List<TourDetails> details = _context.TourDetails.Where(x => x.TourHeaderId == tourId).ToList();
            List<string> result = null;
            for (int i = 0; i < details.Count(); i++)
            {

                TourDetails picked = details.ElementAt(i);


                for (int j = i + 1; j < details.Count(); j++)
                {
                    var comparedDetail = details.ElementAt(j);
                    if ((picked.StartTime < comparedDetail.StartTime && picked.EndTime > comparedDetail.StartTime)
                       || (picked.EndTime > comparedDetail.EndTime && picked.StartTime < comparedDetail.EndTime))
                    {
                        result.Add(picked.Title + " conflicts with " + comparedDetail.Title);

                    }

                    if (picked.StartTime < tour.StartDate || picked.EndTime > tour.EndDate)
                    {
                        result.Add(picked.Title + " is off Tour Time");
                    }

                }
            }


            return result;
        }



        public IEnumerable<string> GetTimeConflicts(int tourId, TourDetails tourDetail)
        {
            var tour = _context.TourHeader.FirstOrDefault(x => x.Id == tourId);
            List<TourDetails> details = _context.TourDetails.Where(x => x.TourHeaderId == tourId).ToList();
            List<string> result = new List<string>();
            var picked = tourDetail;

            DateTime pickedStart = Convert.ToDateTime(picked.StartDate.ToShortDateString() + " " + picked.StartTime.ToShortTimeString());
            DateTime pickedEnd = Convert.ToDateTime(picked.EndDate.ToShortDateString() + " " + picked.EndTime.ToShortTimeString());
            for (int i = 0; i < details.Count(); i++)
            {

                var comparedDetail = details.ElementAt(i);
                if ((pickedStart < comparedDetail.StartTime && pickedEnd > comparedDetail.StartTime)
                    || (pickedEnd > comparedDetail.EndTime && pickedStart < comparedDetail.EndTime))
                {
                    result.Add(picked.Title + " conflicts with " + comparedDetail.Title);

                }

            }
                if (pickedStart < tour.StartDate || pickedEnd > tour.EndDate)
                {
                    result.Add(picked.Title + " is off Tour Time");
                }

            return result;
        }
    }
}
