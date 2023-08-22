using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using ClubManagementRepositories.Models;
using ClubManagementServices.Interfaces;
using ClubManagementServices.ViewModels;

namespace ClubManagement.Pages.ClubActivityPage.Admin
{
    public class DeleteModel : PageModel
    {
        private readonly IClubActivityService _clubActivityService;

        public DeleteModel(IClubActivityService clubActivityService)
        {
            _clubActivityService = clubActivityService;
        }

        [BindProperty]
      public ClubActivityUpdateView ClubActivity { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(Guid? id)
        {
           
            var clubActivity = await _clubActivityService.GetActivityUpdateViewById(id!.Value);

            if (clubActivity == null)
            {
                return NotFound();
            }
            else 
            {
                ClubActivity = clubActivity;
            }
            return Page();
        }

        public async Task<IActionResult> OnPostAsync(Guid? id)
        {
            var clubActivity = await _clubActivityService.GetActivityUpdateViewById(id!.Value);
            await _clubActivityService.Delete(id!.Value);
            return RedirectToPage("./Index",new {id=clubActivity.ClubId});
        }
    }
}
