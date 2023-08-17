using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using ClubManagementRepositories.Models;

namespace ClubManagement.Pages.MemberPage
{
    public class DeleteModel : PageModel
    {
        private readonly ClubManagementRepositories.Models.ClubManagementContext _context;

        public DeleteModel(ClubManagementRepositories.Models.ClubManagementContext context)
        {
            _context = context;
        }

        [BindProperty]
      public Membership Membership { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(Guid? id)
        {
            if (id == null || _context.Memberships == null)
            {
                return NotFound();
            }

            var membership = await _context.Memberships.FirstOrDefaultAsync(m => m.MembershipId == id);

            if (membership == null)
            {
                return NotFound();
            }
            else 
            {
                Membership = membership;
            }
            return Page();
        }

        public async Task<IActionResult> OnPostAsync(Guid? id)
        {
            if (id == null || _context.Memberships == null)
            {
                return NotFound();
            }
            var membership = await _context.Memberships.FindAsync(id);

            if (membership != null)
            {
                Membership = membership;
                _context.Memberships.Remove(Membership);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./Index");
        }
    }
}
