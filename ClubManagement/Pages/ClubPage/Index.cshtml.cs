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
    public class IndexModel : PageModel
    {
        private readonly IClubService _clubService;
        public IndexModel(IClubService clubService)
        {
            _clubService = clubService;
        }

        public IList<ClubView> Club { get; set; } = default!;

        public async Task OnGetAsync()
        {
            var clubs = await _clubService.GetAllClubs();
            if (clubs.Count > 0)
            {
                Club = clubs;
            }
            else
            {
                TempData["error"] = "There is no club in school!";
            }

        }
    }
}
