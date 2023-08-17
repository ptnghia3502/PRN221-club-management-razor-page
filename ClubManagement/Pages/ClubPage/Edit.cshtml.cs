using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using ClubManagementRepositories.Models;
using ClubManagementServices.Interfaces;
using ClubManagementServices.ViewModels;

namespace ClubManagement.Pages.ClubPage
{
    public class EditModel : PageModel
    {
        private readonly IClubService _clubService;

        public EditModel(IClubService clubService)
        {
            _clubService = clubService;
        }

        [BindProperty]
        public ClubUpdateView Club { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(Guid? id)
        {

            Club = await _clubService.GetUpdateInfor(id!.Value);
            if (Club == null)
            {
                return NotFound();
            }
            return Page();
        }

        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            await _clubService.UpdateClub(Club);

            return RedirectToPage("./Index");
        }
    }
}
