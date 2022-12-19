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
    public class EditModel : PageModel
    {
        private readonly ApplicationDbContext _context;

        public EditModel(ApplicationDbContext context)
        {
            _context = context;
        }

        [BindProperty]
        public TourHeader TourHeader { get; set; }

        public async Task<IActionResult> OnGetAsync(int? tourId)
        {
            if (tourId == null)
            {
                return NotFound();
            }

            TourHeader = await _context.TourHeader
                .Include(t => t.ApplicationUser).FirstOrDefaultAsync(m => m.Id == tourId);

            if (TourHeader == null)
            {
                return NotFound();
            }
           ViewData["ManagerId"] = new SelectList(_context.ApplicationUser, "Id", "FullName");
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

            _context.Attach(TourHeader).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!TourHeaderExists(TourHeader.Id))
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

        private bool TourHeaderExists(int id)
        {
            return _context.TourHeader.Any(e => e.Id == id);
        }
    }
}
