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

namespace ClubManagement.Pages.ClubBoardPage
{
    public class CreateModel : PageModel
    {
        private readonly IClubBoardService _clubBoardService;

        public CreateModel(IClubBoardService clubBoardService)
        {
            _clubBoardService = clubBoardService;
        }

        [BindProperty]
        public Guid ClubId { get; set; }
        public IActionResult OnGet(Guid id)
        {
            ClubId = id;
            return Page();
        }
        
        [BindProperty]
        public ClubBoardCreateView ClubBoard { get; set; } = default!;
        

        public async Task<IActionResult> OnPostAsync()
        {
            await _clubBoardService.CreateClubBoard(ClubBoard);
            return RedirectToPage("./Index",new {id=ClubBoard.ClubId});
        }
    }
}
