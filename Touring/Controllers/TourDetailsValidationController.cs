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
    public class TourDetailsValidationController : Controller
    {
        private readonly IUnitOfWork _unitOfwork;

        public TourDetailsValidationController(IUnitOfWork unitOfwork)
        {
            _unitOfwork = unitOfwork;
        }

        [HttpPost]
        public IActionResult GetLoadEvent([FromBody]string eventData)
        {   
            if(eventData != null)
            { 
            string entityType = eventData.Split(',')[0];
            int eventId = Convert.ToInt32(eventData.Split(',')[1]);

            if (entityType != null)
            {
                switch (entityType)
                {
                    case "accommodation":
                        return Json(new { data = _unitOfwork.Accommodation.GetFirstOrDefault(x => x.Id == eventId) });
                    case "trip":
                        return Json(new { data = _unitOfwork.Trip.GetFirstOrDefault(x => x.Id == eventId) });
                    case "activity":
                        return Json(new { data = _unitOfwork.Activity.GetFirstOrDefault(x => x.Id == eventId) });
                    default:
                        return null;
                }
            }
            else
            {
                return null;
            }
            }
            else
            {
                return null;
            }

        }
    }
}
