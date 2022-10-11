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

        public IEnumerable<SelectListItem> GetUsersForDropDown(UserManager<ApplicationUser> userManager,RoleManager<ApplicationRoles> rolemanager,string userRole)
        {

            string roleId = rolemanager.Roles.FirstOrDefault(x => x.Name == userRole).Id;

            var usersByRole = from ur in _context.ApplicationUserRole
                              join u in userManager.Users on ur.UserId equals u.Id
                              select new { role = ur.RoleId, user = u };

            usersByRole = usersByRole.Where(x => x.role == roleId);

            return usersByRole.Select(x => new SelectListItem { 
                Value= x.user.Id,
                Text = x.user.FullName
            });
        }
    }
}
