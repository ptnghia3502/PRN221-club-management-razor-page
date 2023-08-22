using ClubManagementServices.Interfaces;
using ClubManagementServices.Service;
using ClubManagementServices.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace ClubManagement.Pages.StudentClubPage.Member
{
    public class CreateModel : PageModel
    {
        private readonly IMembershipService _membershipService;
        private readonly IMemberClubBoardService _memberClubBoardService;

        public CreateModel(IMembershipService membershipService, IMemberClubBoardService memberClubBoardService)
        {
            _membershipService = membershipService;
            _memberClubBoardService = memberClubBoardService;
        }
        [BindProperty]
        public Guid ClubId { get; set; } = default;
        public async Task<IActionResult> OnGet(Guid id)
        {
            var studentId = HttpContext.Session.GetString("studentId");
            if (studentId == null)
            {
                return RedirectToPage("/Index");
            }

            var listRole = await _memberClubBoardService.GetRoleOfMemberInClub(Guid.Parse(studentId), id);
            if (listRole.Contains("President") || listRole.Contains("Co-President"))
            {
                ClubId = id;
                return Page();
            }
            TempData["NOT_ALLOW"] = "You don't have permission to access this!";
            return RedirectToPage("./Index");
        }

        [BindProperty]
        public MembershipCreateView Membership { get; set; } = default!;


        public async Task<IActionResult> OnPostAsync()
        {
            await _membershipService.CreateMember(Membership);

            return RedirectToPage("./MemberPage");
        }
    }
}
