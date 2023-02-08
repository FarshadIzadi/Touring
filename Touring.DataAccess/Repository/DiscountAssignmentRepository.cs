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
    public class DiscountAssignmentRepository : Repository<DiscountAssignment>, IDiscountAssignmentRepository
    {
        private readonly ApplicationDbContext _context;
        public DiscountAssignmentRepository(ApplicationDbContext context) : base(context)
        {
            _context = context;
        }

        public IEnumerable<DiscountAssignment> getUsersWithDiscount(int discountId)
        {
            return _context.DiscountAssignment.Include(x => x.ApplicationUser).Where(x => x.DiscountId == discountId);
        }
    }
}
