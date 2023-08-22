using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using ClubManagementRepositories.Models;
using ClubManagementServices.ViewModels;
using ClubManagementServices.Interfaces;

namespace ClubManagement.Pages.ClubActivityPage.Admin
{
    public class CreateModel : PageModel
    {
        private readonly IClubActivityService _clubActivityService;

        public CreateModel(IClubActivityService clubActivityService)
        {
            _clubActivityService = clubActivityService;
        }

        [BindProperty]
        public Guid ClubId { get; set; } = default;
        public IActionResult OnGet(Guid id)
        {
            ClubId = id;
            return Page();
        }

        [BindProperty]
        public ClubActivityCreateView ClubActivity { get; set; } = default!;
        

        public async Task<IActionResult> OnPostAsync()
        {
            await _clubActivityService.CreateActivity(ClubActivity);
            return RedirectToPage("./Index",new {id=ClubActivity.ClubId});
        }
    }
}
