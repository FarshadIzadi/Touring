using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Touring.Models;
using Touring.Utility;

namespace Touring.DataAccess.Initializer
{
    public class DbInitializer : IDbInitializer
    {
        private readonly ApplicationDbContext _db;
        private readonly RoleManager<ApplicationRoles> _roleManager;
        private readonly UserManager<ApplicationUser> _userManager;
        public DbInitializer(ApplicationDbContext db,
                            RoleManager<ApplicationRoles> roleManager,
                            UserManager<ApplicationUser> userManager)
        {
            _db = db;
            _roleManager = roleManager;
            _userManager = userManager;
        }

        void IDbInitializer.DbInitializer()
        {
            try { 
                if (_db.Database.GetPendingMigrations().Count() > 0)
                {
                    _db.Database.Migrate();
                }
            }catch(Exception ex) {
                
            }

            if (_roleManager.RoleExistsAsync(SD.RoleManager).GetAwaiter().GetResult()) return;

            _roleManager.CreateAsync(new ApplicationRoles(SD.RoleManager)).GetAwaiter().GetResult();
            _roleManager.CreateAsync(new ApplicationRoles(SD.RoleTourGuide)).GetAwaiter().GetResult();
            _roleManager.CreateAsync(new ApplicationRoles(SD.RoleFrontdesk)).GetAwaiter().GetResult();
            _roleManager.CreateAsync(new ApplicationRoles(SD.RoleAccountant)).GetAwaiter().GetResult();
            _roleManager.CreateAsync(new ApplicationRoles(SD.RoleUser)).GetAwaiter().GetResult();
            _roleManager.CreateAsync(new ApplicationRoles(SD.RoleTourManager)).GetAwaiter().GetResult();

            var user = new ApplicationUser {
                Email = "admin@admin.com",
                UserName = "admin@admin.com",
                EmailConfirmed = true
            };

            _userManager.CreateAsync(user, "asdasd").GetAwaiter().GetResult();

            _userManager.AddToRoleAsync(user, SD.RoleManager).GetAwaiter().GetResult();
        }
    }
}
