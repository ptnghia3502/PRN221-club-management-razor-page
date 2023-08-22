using ClubManagementServices.Interfaces;
using ClubManagementServices.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace ClubManagement.Pages.StudentClubPage.Member
{
    public class MemberPageModel : PageModel
    {
        private readonly IMembershipService _membershipService;
        private readonly IMemberClubBoardService _memberClubBoardService;
        public MemberPageModel(IMembershipService membershipService, IMemberClubBoardService memberClubBoardService)
        {
            _membershipService = membershipService;
            _memberClubBoardService = memberClubBoardService;
        }
        public IList<MembershipView> Membership { get; set; } = default!;
        [BindProperty]
        public Guid ClubId { get; set; } = default;
        public async Task<IActionResult> OnGetAsync(Guid id)
        {
            ClubId = id;
            var result = await _membershipService.GetAllMemberByClubId(id);
            Membership = result;
            return Page();
        }
    }
}
