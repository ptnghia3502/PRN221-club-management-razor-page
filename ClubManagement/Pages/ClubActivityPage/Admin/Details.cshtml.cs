using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using ClubManagementRepositories.Models;
using ClubManagementServices.Interfaces;

namespace ClubManagement.Pages.ClubActivityPage.Admin
{
    public class DetailsModel : PageModel
    {
        private readonly IClubActivityService _clubActivityService;

        public DetailsModel(IClubActivityService clubActivityService)
        {
            _clubActivityService = clubActivityService;
        }

      public ClubActivity ClubActivity { get; set; } = default!; 

        public async Task<IActionResult> OnGetAsync(Guid? id)
        {
            ClubActivity = await _clubActivityService.GetActivityById(id!.Value);
            return Page();
        }
    }
}
