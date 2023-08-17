using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using ClubManagementRepositories.Models;

namespace ClubManagement.Pages.ClubBoardPage
{
    public class EditModel : PageModel
    {
        private readonly ClubManagementRepositories.Models.ClubManagementContext _context;

        public EditModel(ClubManagementRepositories.Models.ClubManagementContext context)
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

            var clubboard =  await _context.ClubBoards.FirstOrDefaultAsync(m => m.ClubBoardId == id);
            if (clubboard == null)
            {
                return NotFound();
            }
            ClubBoard = clubboard;
           ViewData["ClubId"] = new SelectList(_context.Clubs, "ClubId", "ClubId");
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

            _context.Attach(ClubBoard).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ClubBoardExists(ClubBoard.ClubBoardId))
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

        private bool ClubBoardExists(Guid id)
        {
          return (_context.ClubBoards?.Any(e => e.ClubBoardId == id)).GetValueOrDefault();
        }
    }
}
