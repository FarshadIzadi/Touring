using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Touring.DataAccess.Repository.IRepository;

namespace Touring.DataAccess.Repository
{
    public class UnitOfWork : IUnitOfWork
    {
        public readonly ApplicationDbContext _context;

        public UnitOfWork(ApplicationDbContext context)
        {
            _context = context;
            ApplicationUser = new ApplicationUserRepository(_context);
            TourHeader = new TourHeaderRepository(_context);
            TourDetails = new TourDetailsRepository(_context);
            Activity = new ActivityRepository(_context);
        }

        public IApplicationUserRepository ApplicationUser { get; private set; }
        public ITourHeaderRepository TourHeader { get; private set; }
        public ITourDetailsRepository TourDetails { get; private set; }
        public IActivityRepository Activity { get; private set; }
        public void Dispose()
        {
            _context.Dispose();
        }

        public void Save()
        {
            _context.SaveChanges();
        }
    }
}
