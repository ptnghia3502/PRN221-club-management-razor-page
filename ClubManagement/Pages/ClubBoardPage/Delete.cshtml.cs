using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using ClubManagementRepositories.Models;

namespace ClubManagement.Pages.ClubBoardPage
{
    public class DeleteModel : PageModel
    {
        private readonly ClubManagementRepositories.Models.ClubManagementContext _context;

        public DeleteModel(ClubManagementRepositories.Models.ClubManagementContext context)
        {
            _context = context;
        }

        [BindProperty]
      public ClubBoard ClubBoard { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(Guid? id)
        {
            if (id == null || _context.ClubBoards == null)
            {
                return NotFound();
            }

            var clubboard = await _context.ClubBoards.FirstOrDefaultAsync(m => m.ClubBoardId == id);

            if (clubboard == null)
            {
                return NotFound();
            }
            else 
            {
                ClubBoard = clubboard;
            }
            return Page();
        }

        public async Task<IActionResult> OnPostAsync(Guid? id)
        {
            if (id == null || _context.ClubBoards == null)
            {
                return NotFound();
            }
            var clubboard = await _context.ClubBoards.FindAsync(id);

            if (clubboard != null)
            {
                ClubBoard = clubboard;
                _context.ClubBoards.Remove(ClubBoard);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./Index");
        }
    }
}
