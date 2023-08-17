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

namespace ClubManagement.Pages.ClubPage
{
    public class DetailsModel : PageModel
    {
        private readonly IClubService _clubService;

        public DetailsModel(IClubService clubService)
        {
            _clubService = clubService;
        }

        public ClubView Club { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var club = await _clubService.GetClubById(id.Value);
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
    }
}
