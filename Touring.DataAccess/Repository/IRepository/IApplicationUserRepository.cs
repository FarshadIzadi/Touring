using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Touring.Models;

namespace Touring.DataAccess.Repository.IRepository
{
    public interface IApplicationUserRepository : IRepository<ApplicationUser>
    {
        IEnumerable<SelectListItem> GetUsersForDropDown(UserManager<ApplicationUser> userManager, RoleManager<ApplicationRoles> rolemanager, string userRole);
        IEnumerable<UserRoles> GetUsersWithRoles();
    }
}
