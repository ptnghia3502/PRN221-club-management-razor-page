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
using ClubManagementServices.Service;

namespace ClubManagement.Pages.ClubActivityPage.Member
{
    public class CreateModel : PageModel
    {
        private readonly IClubActivityService _clubActivityService;
        private readonly IMemberClubBoardService _memberClubBoardService;


        public CreateModel(IClubActivityService clubActivityService, IMemberClubBoardService memberClubBoardService)
        {
            _clubActivityService = clubActivityService;
            _memberClubBoardService = memberClubBoardService;
        }

        [BindProperty]
        public Guid ClubId { get; set; } = default;
        public async Task<IActionResult> OnGet(Guid id)
        {
            var studentId = HttpContext.Session.GetString("studentId");
            if (studentId == null)
            {
                return RedirectToPage("/StudentClubPage/Index", "OnGetAsync");
            }

            var listRole = await _memberClubBoardService.GetRoleOfMemberInClub(Guid.Parse(studentId), id);
            if (listRole != null)
            {
                if (listRole.Contains("President") || listRole.Contains("Co-President"))
                {
                    ClubId = id;
                    return Page();
                }
            }
            TempData["NOT_ALLOW"] = "You don't have permission to access this!";
            return RedirectToPage("/StudentClubPage/Index", "OnGetAsync");
            
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
