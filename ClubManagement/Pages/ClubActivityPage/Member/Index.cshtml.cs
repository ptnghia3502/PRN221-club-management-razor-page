using ClubManagementRepositories.Models;
using ClubManagementServices.Interfaces;
using ClubManagementServices.Service;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace ClubManagement.Pages.ClubActivityPage.Member
{
    public class IndexModel : PageModel
    {
        private readonly IClubActivityService _clubActivityService;
        private readonly IMemberClubBoardService _memberClubBoardService;

        public IndexModel(IClubActivityService clubActivityService, IMemberClubBoardService memberClubBoardService)
        {
            _clubActivityService = clubActivityService;
            _memberClubBoardService = memberClubBoardService;
        }

        public IList<ClubActivity> ClubActivity { get; set; } = default!;

        [BindProperty]
        public Guid ClubId { get; set; } = default;
        public async Task<IActionResult> OnGetAsync(Guid id)
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
                    ClubActivity = await _clubActivityService.GetAllActivitiesByClubId(id);
                    return Page();
                }
            }
            TempData["NOT_ALLOW"] = "You don't have permission to access this!";
            return RedirectToPage("/StudentClubPage/Index", "OnGetAsync");   
        }
    }
}
