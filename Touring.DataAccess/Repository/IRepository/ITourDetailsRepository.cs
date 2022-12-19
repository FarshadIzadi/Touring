using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Touring.Models;

namespace Touring.DataAccess.Repository.IRepository
{
    public interface ITourDetailsRepository : IRepository<TourDetails>
    {
        IEnumerable<string> GetTimeConflicts(int tourId);
        IEnumerable<string> GetTimeConflicts(int tourId,TourDetails tourDetail);
    }
}
