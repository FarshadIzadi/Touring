﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Touring.DataAccess;
using Touring.Models;

namespace Touring.Pages.Admin.Accommodation
{
    public class DetailsModel : PageModel
    {
        private readonly ApplicationDbContext _context;

        public DetailsModel(ApplicationDbContext context)
        {
            _context = context;
        }

        public Models.Accommodation Accommodation { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Accommodation = await _context.Accommodation.FirstOrDefaultAsync(m => m.Id == id);

            if (Accommodation == null)
            {
                return NotFound();
            }
            return Page();
        }
    }
}
