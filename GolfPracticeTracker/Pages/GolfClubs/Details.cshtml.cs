﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using GolfPracticeTracker.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using GolfPracticeTracker.Models;
using Microsoft.EntityFrameworkCore;

namespace GolfPracticeTracker.Pages.GolfClubs
{
    public class DetailsModel : PageModel
    {
        private readonly GolfPracticeTrackerContext _context;

        public DetailsModel(GolfPracticeTrackerContext context)
        {
            _context = context;
        }

        public GolfClub GolfClub { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            GolfClub = await _context.GolfClubs.FirstOrDefaultAsync(m => m.ID == id);

            if (GolfClub == null)
            {
                return NotFound();
            }
            return Page();
        }
    }
}
