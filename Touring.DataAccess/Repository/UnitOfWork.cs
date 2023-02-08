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
            Accommodation = new AccommodationRepository(_context);
            Trip = new TripRepository(_context);
            Meal = new MealRepository(_context);
            PassengerGroups = new PassengerGroupsRepository(_context);
            TourBook = new TourBookRepository(_context);
            Discount = new DiscountsRepository(_context);
            DiscountAssignment = new DiscountAssignmentRepository(_context);
            Payments = new PaymentsRepository(_context);
        }

        public IApplicationUserRepository ApplicationUser { get; private set; }
        public ITourHeaderRepository TourHeader { get; private set; }
        public ITourDetailsRepository TourDetails { get; private set; }
        public IActivityRepository Activity { get; private set; }
        public IAccommodationRepository Accommodation { get; private set; }
        public ITripRepository Trip { get; private set; }
        public IMealRepository Meal { get; private set; }
        public IPassengerGroupsRepository PassengerGroups { get; private set; }
        public ITourBookRepository TourBook { get; private set; }
        public IDiscountsRepository Discount { get; private set; }
        public IDiscountAssignmentRepository DiscountAssignment { get; private set; }
        public IPaymentsRepository Payments { get; private set; }
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
