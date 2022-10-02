using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Touring.DataAccess.Repository.IRepository;
using Touring.Models;
using Touring.Utility;

namespace Touring.DataAccess.Repository
{
    public class ApplicationUserRepository : Repository<ApplicationUser>, IApplicationUserRepository
    {
        private readonly ApplicationDbContext _context;
        public ApplicationUserRepository(ApplicationDbContext context) : base(context)
        {
            _context = context;
        }

        public IEnumerable<SelectListItem> GetUsersForDropDown(string userRole)
        {
            //var allUsers = userManager.Users.Include(u => u.ApplicationUserRoles).ThenInclude(r => r.Role);

            //var usersInRole = allUsers.Where(x => x.ApplicationUserRoles.Any(r => r.Role.Name == userRole));
            //return usersInRole.Select(x => new SelectListItem
            //{
            //    Value = x.Id,
            //    Text = x.FullName
            //});

            return null;
        }
    }
}
