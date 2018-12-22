using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using GolfPracticeTracker.Data;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using GolfPracticeTracker.Models;

namespace GolfPracticeTracker.Pages.Players
{
    public class IndexModel : PageModel
    {
        private readonly GolfPracticeTrackerContext _context;

        public IndexModel(GolfPracticeTrackerContext context)
        {
            _context = context;
        }

        public PaginatedList<Player> Player { get; set; }
        public string NameSort { get; set; }  
        public string DateSort { get; set; }
        public string CurrentFilter { get; set; }
        public string CurrentSort { get; set; }

        public async Task OnGetAsync(string sortOrder, string currentFilter, string searchString, int? pageIndex)
        {
            CurrentSort = sortOrder;
            NameSort = String.IsNullOrEmpty(sortOrder) ? "name_desc" : "";
            DateSort = sortOrder == "Date" ? "date_desc" : "Date";
            if (searchString != null)
            {
                pageIndex = 1;
            }
            else
            {
                searchString = currentFilter;
            }

            CurrentFilter = searchString;

            IQueryable<Player> playerIQ = from p in _context.Players
                select p;

            if (!String.IsNullOrEmpty(searchString))
            {
                playerIQ = playerIQ.Where(p => p.LastName.Contains(searchString) || p.FirstName.Contains(searchString));
            }

            switch (sortOrder)
            {
                case "name_desc":
                    playerIQ = playerIQ.OrderByDescending(p => p.LastName).ThenByDescending(p => p.FirstName);
                    break;
                //case "Date":
                //    playerIQ = playerIQ.OrderBy(p => p.SomeDate);
                //    break;
                //case "desc_date":
                //    playerIQ = playerIQ.OrderByDescending(p => p.SomeDate);
                //    break;
                default:
                    playerIQ = playerIQ.OrderBy(p => p.LastName).ThenBy(p => p.FirstName);
                    break;

            }
            int pageSize = 3;
            Player = await PaginatedList<Player>.CreateAsync(
                playerIQ.AsNoTracking(), pageIndex ?? 1, pageSize);
        }
    }
}
