using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Touring.DataAccess;
using Touring.DataAccess.Repository.IRepository;
using Touring.Models;
using Touring.Utility;

namespace Touring.Pages.Admin.ManageDiscounts
{
    public class CreateModel : PageModel
    {
        private readonly ApplicationDbContext _context;
        private readonly IUnitOfWork _unitOfWork;
        public CreateModel(ApplicationDbContext context, IUnitOfWork unitOfWork)
        {
            _context = context;
            _unitOfWork = unitOfWork;
        }


        [BindProperty]
        public Discounts discountData { get; set; }
        [BindProperty]
        public bool allUsers { get; set; }
        public List<string> Errors { get; set; }
        public IActionResult OnGet(int? discountId)
        {

            if ((discountId ?? 0) != 0)
            {
                discountData = _unitOfWork.Discount.GetFirstOrDefault(x => x.Id == discountId);
            }

            allUsers = false;
            return Page();

        }

        // To protect from overposting attacks, see https://aka.ms/RazorPagesCRUD
        public IActionResult OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }
            int discountId;
            Errors = new List<string>();
            var discountObj = _unitOfWork.Discount.GetFirstOrDefault(x => x.Id == discountData.Id);
            if (discountObj != null)
            {

                var assignedDiscounts = _unitOfWork.DiscountAssignment.GetAll(x => x.DiscountId == discountObj.Id && x.applied == true);
                
                if (discountObj.ValidFrom <= DateTime.Now)
                {
                    Errors.Add("Discounts can only be edited before validation time begins!");
                }
                if (assignedDiscounts != null && assignedDiscounts.Count() > 0)
                {
                    Errors.Add("Edit not possible. Some User have already applied discount code.");
                }

                if(Errors.Count() > 0)
                {
                    return Page();
                }else
                {

                    IEnumerable<DiscountAssignment> removeableDiscounts = _unitOfWork.DiscountAssignment.GetAll(x => x.DiscountId == discountObj.Id);
                    _unitOfWork.DiscountAssignment.RemoveRange(removeableDiscounts);
                    discountObj.DiscountTitle = discountData.DiscountTitle;
                    discountObj.DiscountCode = discountData.DiscountCode;
                    discountObj.ValidFrom = discountData.ValidFrom;
                    discountObj.ValidUntill = discountData.ValidUntill;
                    discountObj.DiscountPercentage = discountData.DiscountPercentage;
                    discountObj.DiscountAmount = discountData.DiscountAmount;

                    _unitOfWork.Discount.Update(discountObj);
                    _unitOfWork.Save();
                    discountId = discountObj.Id;
                }
            }//End of discount Exists so it's an edit
            else {
                _unitOfWork.Discount.Add(discountData);
                _unitOfWork.Save();
                discountId = discountData.Id;
            }

            var formData = HttpContext.Request.Form;

            List<ApplicationUser> users = _unitOfWork.ApplicationUser.GetAll().ToList();
            if (!allUsers)
            {
                if ((formData["joinedBefore"][0] ?? "") != "")
                {
                    DateTime joinedBefore = Convert.ToDateTime(formData["joinedBefore"][0]);
                    users = users.Where(x => x.JoinDate < joinedBefore).ToList();
                }

                if ((formData["joinedAfter"][0] ?? "") != "")
                {
                    DateTime joinedAfter = Convert.ToDateTime(formData["joinedAfter"][0]);
                    users = users.Where(x => x.JoinDate < joinedAfter).ToList();
                }

                string moreThan = formData["moreThan"][0];
                if ((moreThan ?? "") != "" && Convert.ToDecimal(moreThan) > 0)
                {
                    var tempUsers = users;
                    users = new List<ApplicationUser>();
                    foreach (var user in tempUsers)
                    {
                        var payments = _unitOfWork.Payments.GetAll(x => x.UserId == user.Id);
                        decimal sum = 0;
                        foreach (var payment in payments)
                        {
                            sum = sum + payment.MoneyIn - payment.MoneyOut;
                        }

                        if (sum > Convert.ToDecimal(moreThan))
                        {
                            users.Add(user);
                        }

                    }
                }



                string lessThan = formData["lessThan"][0];
                if ((lessThan ?? "") != "" && Convert.ToDecimal(lessThan) > 0)
                {
                    var tempUsers = users;
                    users = new List<ApplicationUser>();
                    foreach (var user in tempUsers)
                    {
                        var payments = _unitOfWork.Payments.GetAll(x => x.UserId == user.Id);
                        decimal sum = 0;
                        foreach (var payment in payments)
                        {
                            sum = sum + payment.MoneyIn - payment.MoneyOut;
                        }

                        if (sum < Convert.ToDecimal(lessThan))
                        {
                            users.Add(user);
                        }

                    }
                }

                string toursTaken = formData["toursTaken"][0];
                if ((toursTaken ?? "") != "" && Convert.ToInt32(toursTaken) > 0)
                {
                    var tempUsers = users;
                    users = new List<ApplicationUser>();
                    foreach (var user in tempUsers)
                    {
                        var tourbooks = _unitOfWork.TourBook.GetAll(x => x.UserId == user.Id && x.Status == SD.BookingStatusBooked);
                        if (tourbooks.Count() >= Convert.ToInt32(toursTaken))
                        {
                            users.Add(user);
                        }
                    }
                }



            }//end of allUsers not checked





            foreach (var user in users)
            {
                DiscountAssignment discountAssignment = new DiscountAssignment()
                {
                    UserId = user.Id,
                    DiscountId = discountId

                };
                _unitOfWork.DiscountAssignment.Add(discountAssignment);
            }
            _unitOfWork.Save();

            return RedirectToPage("./Index");
        }
    }

}
