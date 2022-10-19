using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Touring.DataAccess.Repository.IRepository
{
    public interface IUnitOfWork : IDisposable
    {
        public IApplicationUserRepository ApplicationUser { get; }
        public ITourHeaderRepository TourHeader { get; }
        public ITourDetailsRepository TourDetails { get; }
        public IActivityRepository Activity { get; }
        public IAccommodationRepository Accommodation { get; }
        public void Save();
    }
}
