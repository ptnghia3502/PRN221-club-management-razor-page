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
    public class IndexModel : PageModel
    {
        private readonly IClubActivityService _clubActivityService;

        public IndexModel(IClubActivityService clubActivityService)
        {
            _clubActivityService = clubActivityService;
        }

        public IList<ClubActivity> ClubActivity { get;set; } = default!;

        [BindProperty]
        public Guid ClubId { get; set; } = default;
        public async Task OnGetAsync(Guid id)
        {
            ClubId = id;
            ClubActivity = await _clubActivityService.GetAllActivitiesByClubId(id);
        }
    }
}
