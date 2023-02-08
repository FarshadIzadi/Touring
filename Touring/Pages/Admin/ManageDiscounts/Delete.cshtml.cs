using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Touring.DataAccess;
using Touring.Models;

namespace Touring.Pages.Admin.ManageDiscounts
{
    public class DeleteModel : PageModel
    {
        private readonly Touring.DataAccess.ApplicationDbContext _context;

        public DeleteModel(Touring.DataAccess.ApplicationDbContext context)
        {
            _context = context;
        }

        [BindProperty]
        public Discounts Discounts { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Discounts = await _context.Discounts.FirstOrDefaultAsync(m => m.Id == id);

            if (Discounts == null)
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

            Discounts = await _context.Discounts.FindAsync(id);

            if (Discounts != null)
            {
                _context.Discounts.Remove(Discounts);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./Index");
        }
    }
}
