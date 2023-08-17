using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using ClubManagementRepositories.Models;
using ClubManagementServices.Interfaces;
using ClubManagementServices.ViewModels;
using ClubManagementServices.Service;

namespace ClubManagement.Pages.ClubPage
{
    public class CreateModel : PageModel
    {
        private readonly IClubService _clubService;
        private readonly IStudentService _studentService;

        public CreateModel(IClubService clubService, IStudentService studentService)
        {
            _clubService = clubService;
            _studentService = studentService;
        }
        public async Task<IActionResult> OnGet()
        {
            return Page();
        }

        [BindProperty]
        public ClubCreateView Club { get; set; } = default!;

        public async Task<IActionResult> OnPostAsync()
        {
            await _clubService.CreateClub(Club);
            return RedirectToPage("./Index");
        }
    }
}
