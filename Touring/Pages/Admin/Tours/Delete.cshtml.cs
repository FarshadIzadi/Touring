using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Touring.DataAccess;
using Touring.Models;

namespace Touring.Pages.Admin.Tours
{
    public class DeleteModel : PageModel
    {
        private readonly Touring.DataAccess.ApplicationDbContext _context;

        public DeleteModel(Touring.DataAccess.ApplicationDbContext context)
        {
            _context = context;
        }

        [BindProperty]
        public TourHeader TourHeader { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            TourHeader = await _context.TourHeader
                .Include(t => t.ApplicationUser).FirstOrDefaultAsync(m => m.Id == id);

            if (TourHeader == null)
            {
                return NotFound();
            }
            return Page();
        }

        public async Task<IActionResult> OnPostAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            TourHeader = await _context.TourHeader.FindAsync(id);

            if (TourHeader != null)
            {
                _context.TourHeader.Remove(TourHeader);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./Index");
        }
    }
}
