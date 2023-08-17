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
using ClubManagementServices.Service;
using ClubManagementServices.ViewModels;

namespace ClubManagement.Pages.ClubBoardPage
{
    public class EditModel : PageModel
    {
        private readonly IClubBoardService _clubBoardService;

        public EditModel(IClubBoardService clubBoardService)
        {
            _clubBoardService = clubBoardService;
        }

        [BindProperty]
        public ClubBoardUpdateView ClubBoard { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var clubBoard = await _clubBoardService.GetClubBoardById(id.Value);
            if (clubBoard == null)
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

            await _clubBoardService.UpdateClubBoard(ClubBoard);

            return RedirectToPage("./Index");
        }

    }
}
