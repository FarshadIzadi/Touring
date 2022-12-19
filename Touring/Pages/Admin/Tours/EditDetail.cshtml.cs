using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Touring.DataAccess;
using Touring.Models;

namespace Touring.Pages.Admin.Tours
{
    public class EditDetailModel : PageModel
    {
        private readonly ApplicationDbContext _context;

        public EditDetailModel(ApplicationDbContext context)
        {
            _context = context;
        }

        [BindProperty]
        public TourDetails TourDetails { get; set; }

        public async Task<IActionResult> OnGetAsync(int? detailId)
        {
            if (detailId == null)
            {
                return NotFound();
            }

            TourDetails = await _context.TourDetails
                .Include(t => t.Accommodation)
                .Include(t => t.Activity)
                .Include(t => t.ApplicationUser)
                .Include(t => t.Meal)
                .Include(t => t.TourHeader)
                .Include(t => t.Trip).FirstOrDefaultAsync(m => m.Id == detailId);

            if (TourDetails == null)
            {
                return NotFound();
            }
           ViewData["AccommodationId"] = new SelectList(_context.Accommodation, "Id", "Address");
           ViewData["ActivityId"] = new SelectList(_context.Activity, "Id", "Address");
           ViewData["TourGuideId"] = new SelectList(_context.ApplicationUser, "Id", "Id");
           ViewData["MealId"] = new SelectList(_context.Meals, "Id", "Id");
           ViewData["TourHeaderId"] = new SelectList(_context.TourHeader, "Id", "DestinationCities");
           ViewData["TripId"] = new SelectList(_context.Trip, "Id", "DestinationCity");
            return Page();
        }

        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Attach(TourDetails).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!TourDetailsExists(TourDetails.Id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return RedirectToPage("./Index");
        }

        private bool TourDetailsExists(int id)
        {
            return _context.TourDetails.Any(e => e.Id == id);
        }
    }
}
