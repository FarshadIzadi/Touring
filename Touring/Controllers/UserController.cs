using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Touring.DataAccess.Repository.IRepository;

namespace Touring.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : Controller
    { 
        private readonly IUnitOfWork _unitOfWork;

        public UserController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        [HttpGet]
        public IActionResult Get()
        {
            return Json(new { data = _unitOfWork.ApplicationUser.GetUsersWithRoles() });
        }
    }
}
