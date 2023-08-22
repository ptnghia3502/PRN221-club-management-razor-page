using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using ClubManagementRepositories.Models;
using ClubManagementServices.Interfaces;

namespace ClubManagement.Pages.ClubActivityPage.Member
{
    public class DetailsModel : PageModel
    {
        private readonly IClubActivityService _clubActivityService;
        private readonly IMemberClubBoardService _memberClubBoardService;
        public DetailsModel(IClubActivityService clubActivityService, IMemberClubBoardService memberClubBoardService)
        {
            _clubActivityService = clubActivityService;
            _memberClubBoardService = memberClubBoardService;
        }

        public ClubActivity ClubActivity { get; set; } = default!; 

        public async Task<IActionResult> OnGetAsync(Guid? id)
        {
            var clubActi= await _clubActivityService.GetActivityById(id!.Value);
            var studentId = HttpContext.Session.GetString("studentId");
            if (studentId == null)
            {
                return RedirectToPage("/StudentClubPage/Index", "OnGetAsync");
            }

            var listRole = await _memberClubBoardService.GetRoleOfMemberInClub(Guid.Parse(studentId), clubActi.ClubId!.Value);
            if (listRole != null)
            {
                if (listRole.Contains("President") || listRole.Contains("Co-President"))
                {
                    ClubActivity = clubActi;
                    return Page();
                }
            }
            TempData["NOT_ALLOW"] = "You don't have permission to access this!";
            return RedirectToPage("/StudentClubPage/Index", "OnGetAsync");
            
        }
    }
}
