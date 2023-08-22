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

namespace ClubManagement.Pages.ClubActivityPage.Member
{
    public class DeleteModel : PageModel
    {
        private readonly IClubActivityService _clubActivityService;
        private readonly IMemberClubBoardService _memberClubBoardService;

        public DeleteModel(IClubActivityService clubActivityService, IMemberClubBoardService memberClubBoardService)
        {
            _clubActivityService = clubActivityService;
            _memberClubBoardService = memberClubBoardService;
        }

        [BindProperty]
      public ClubActivityUpdateView ClubActivity { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(Guid? id)
        {
            var clubActivity = await _clubActivityService.GetActivityUpdateViewById(id!.Value);
            var studentId = HttpContext.Session.GetString("studentId");
            if (studentId == null)
            {
                return RedirectToPage("/StudentClubPage/Index", "OnGetAsync");
            }

            var listRole = await _memberClubBoardService.GetRoleOfMemberInClub(Guid.Parse(studentId), clubActivity.ClubId!.Value);
            if (listRole != null)
            {
                if (listRole.Contains("President") || listRole.Contains("Co-President"))
                {
                    

                    if (clubActivity == null)
                    {
                        return NotFound();
                    }
                    else
                    {
                        ClubActivity = clubActivity;
                    }
                    return Page();
                }
            }
            TempData["NOT_ALLOW"] = "You don't have permission to access this!";
            return RedirectToPage("/StudentClubPage/Index", "OnGetAsync");

           
        }

        public async Task<IActionResult> OnPostAsync(Guid? id)
        {
            var clubActivity = await _clubActivityService.GetActivityUpdateViewById(id!.Value);
            await _clubActivityService.Delete(id!.Value);
            return RedirectToPage("./Index",new {id=clubActivity.ClubId});
        }
    }
}
