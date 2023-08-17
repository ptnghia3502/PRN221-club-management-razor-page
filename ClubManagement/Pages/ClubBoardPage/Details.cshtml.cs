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

namespace ClubManagement.Pages.ClubBoardPage
{
    public class DetailsModel : PageModel
    {
        private readonly IClubBoardService _clubBoardService;

        public DetailsModel(IClubBoardService clubBoardService)
        {
            _clubBoardService = clubBoardService;
        }

        public ClubBoardView ClubBoard { get; set; } = default!; 

        public async Task<IActionResult> OnGetAsync(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var clubboard = await _clubBoardService.GetClubBoardById(id.Value);
            if (clubboard == null)
            {
                return NotFound();
            }
            else 
            {
                ClubBoard = clubboard;
            }
            return Page();
        }
    }
}
