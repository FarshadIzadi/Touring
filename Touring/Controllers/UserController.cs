using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Touring.DataAccess;
using Touring.DataAccess.Repository.IRepository;
using Touring.Models;

namespace Touring.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : Controller
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly ApplicationDbContext _context;
        private readonly UserManager<ApplicationUser> _userManager;
        public UserController(IUnitOfWork unitOfWork, ApplicationDbContext context, UserManager<ApplicationUser> userManager)
        {
            _unitOfWork = unitOfWork;
            _context = context;
            _userManager = userManager;
        }

        [HttpGet]
        public IActionResult Get()
        {

            //var appUsers = 
            //            from u in _context.ApplicationUser
            //            join ur in _context.ApplicationUserRole on u.Id equals ur.UserId
            //            select new { users = u, roles = ur.RoleId };

            var roles =
                        from ur in _context.ApplicationUserRole.ToList()
                        join r in _context.ApplicationRoles.ToList() on ur.RoleId equals r.Id
                        select new { rId = ur.RoleId, uId = ur.UserId, rName = r.Name };

            var appUsers = _userManager.Users.ToList().GroupJoin(
                roles.ToList(),
                uid => uid.Id,
                urid => urid.uId,
                (us, rs) => new
                {
                    users = us,
                    userRoles = rs.Select(x => x.rName)
                });




            return Json(new { data = appUsers });
        }
    }
}
