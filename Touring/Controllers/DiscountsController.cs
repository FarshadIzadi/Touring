using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Touring.DataAccess.Repository.IRepository;
using Touring.Models;

namespace Touring.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DiscountsController : Controller
    {
        private readonly IUnitOfWork _unitOfWork;

        public DiscountsController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        [HttpGet]
        public IActionResult Get()
        {
            var discounts = _unitOfWork.Discount.GetAll();


            List<DiscountData> discountData = new List<DiscountData>();
            foreach (var discount in discounts)
            {
                discountData.Add(new DiscountData
                {
                    Discount = discount,
                    Users = _unitOfWork.DiscountAssignment.getUsersWithDiscount(discount.Id)
                }) ;
            }
            return Json(new { data = discountData });
        }
    }

    public class DiscountData
    {
        public Discounts Discount { get; set; }
        public IEnumerable<DiscountAssignment> Users { get; set; }
    }
}
