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

namespace ClubManagement.Pages.ClubActivityPage.Admin
{
    public class EditModel : PageModel
    {
        private readonly IClubActivityService _clubActivityService;
        public EditModel(IClubActivityService clubActivityService)
        {
            _clubActivityService = clubActivityService;
        }

        [BindProperty]
        public ClubActivityUpdateView ClubActivity { get; set; } = default!;
        [BindProperty]
        public Guid ClubId { get; set; } = default;
        public async Task<IActionResult> OnGetAsync(Guid? id,Guid? clubid)
        {
            ClubId = clubid!.Value;
            var clubactivity = await _clubActivityService.GetActivityUpdateViewById(id!.Value);
            if (clubactivity == null)
            {
                return NotFound();
            }
            ClubActivity = clubactivity;
            return Page();
        }

        
        public async Task<IActionResult> OnPostAsync()
        {
            ClubActivity.ClubId = ClubId;
            await _clubActivityService.UpdateActivity(ClubActivity);

            return RedirectToPage("./Index",new {id=ClubId});
        }

    }
}
