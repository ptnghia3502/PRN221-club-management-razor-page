using ClubManagementRepositories.Models;
using ClubManagementServices.Interfaces;
using ClubManagementServices.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace ClubManagement.Pages.StudentClubPage.Member
{
    public class DeleteModel : PageModel
    {
        private readonly IMembershipService _membershipService;
        private readonly IMemberClubBoardService _memberClubBoardService;
        public DeleteModel(IMembershipService membershipService, IMemberClubBoardService memberClubBoardService)
        {
            _membershipService = membershipService;
            _memberClubBoardService = memberClubBoardService;

        }
        [BindProperty]
        public MembershipView Membership { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(Guid? id)
        {
            var membership = await _membershipService.GetMemberById(id.Value);
            var studentId = HttpContext.Session.GetString("studentId");
            if (studentId == null)
            {
                return RedirectToPage("./MemberPage", "OnGetAsync", new { id = membership.Club!.ClubId });
            }

            var listRole = await _memberClubBoardService.GetRoleOfMemberInClub(Guid.Parse(studentId), membership.Club!.ClubId);
            if (listRole != null)
            {
                if (listRole.Contains("President") || listRole.Contains("Co-President"))
                {
                    if (membership == null)
                    {
                        return NotFound();
                    }
                    else
                    {
                        Membership = membership;
                    }
                    return Page();
                }
            }

            TempData["NOT_ALLOW"] = "You don't have permission to access this!";
            return RedirectToPage("./MemberPage", "OnGetAsync", new { id = membership.Club!.ClubId });


        }
        public async Task<IActionResult> OnPostAsync(Guid? id)
        {
            var membership = await _membershipService.GetMemberById(id!.Value);
            await _membershipService.Delete(id!.Value);
            return RedirectToPage("./MemberPage", new { id = membership.Club!.ClubId });
        }
    }
}
