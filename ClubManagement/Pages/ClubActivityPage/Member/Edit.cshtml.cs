using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using ClubManagementRepositories.Models;
using ClubManagementServices.Interfaces;
using ClubManagementServices.ViewModels;

namespace ClubManagement.Pages.ClubActivityPage.Member
{
    public class EditModel : PageModel
    {
        private readonly IClubActivityService _clubActivityService;
        private readonly IMemberClubBoardService _memberClubBoardService;
        public EditModel(IClubActivityService clubActivityService, IMemberClubBoardService memberClubBoardService)
        {
            _clubActivityService = clubActivityService;
            _memberClubBoardService = memberClubBoardService;
        }

        [BindProperty]
        public ClubActivityUpdateView ClubActivity { get; set; } = default!;
        [BindProperty]
        public Guid ClubId { get; set; } = default;
        public async Task<IActionResult> OnGetAsync(Guid? id,Guid? clubid)
        {
            var studentId = HttpContext.Session.GetString("studentId");
            if (studentId == null)
            {
                return RedirectToPage("/StudentClubPage/Index", "OnGetAsync");
            }

            var listRole = await _memberClubBoardService.GetRoleOfMemberInClub(Guid.Parse(studentId), clubid!.Value);
            if (listRole != null)
            {
                if (listRole.Contains("President") || listRole.Contains("Co-President"))
                {
                    ClubId = clubid!.Value;
                    var clubactivity = await _clubActivityService.GetActivityUpdateViewById(id!.Value);
                    if (clubactivity == null)
                    {
                        return NotFound();
                    }
                    ClubActivity = clubactivity;
                    return Page();
                }
            }
            TempData["NOT_ALLOW"] = "You don't have permission to access this!";
            return RedirectToPage("/StudentClubPage/Index", "OnGetAsync");

            
        }

        
        public async Task<IActionResult> OnPostAsync()
        {
            ClubActivity.ClubId = ClubId;
            await _clubActivityService.UpdateActivity(ClubActivity);

            return RedirectToPage("./Index",new {id=ClubId});
        }

    }
}
