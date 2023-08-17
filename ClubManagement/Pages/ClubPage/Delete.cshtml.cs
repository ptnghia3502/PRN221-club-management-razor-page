using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using ClubManagementRepositories.Models;

namespace ClubManagement.Pages.ClubPage
{
    public class DeleteModel : PageModel
    {
        private readonly ClubManagementRepositories.Models.ClubManagementContext _context;

        public DeleteModel(ClubManagementRepositories.Models.ClubManagementContext context)
        {
            _context = context;
        }

        [BindProperty]
      public Club Club { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(Guid? id)
        {
            if (id == null || _context.Clubs == null)
            {
                return NotFound();
            }

            var club = await _context.Clubs.FirstOrDefaultAsync(m => m.ClubId == id);

            if (club == null)
            {
                return NotFound();
            }
            else 
            {
                Club = club;
            }
            return Page();
        }

        public async Task<IActionResult> OnPostAsync(Guid? id)
        {
            if (id == null || _context.Clubs == null)
            {
                return NotFound();
            }
            var club = await _context.Clubs.FindAsync(id);

            if (club != null)
            {
                Club = club;
                _context.Clubs.Remove(Club);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./Index");
        }
    }
}
