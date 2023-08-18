using ClubManagementServices.Interfaces;
using ClubManagementServices.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace ClubManagement.Pages.StudentClubPage
{
    public class IndexModel : PageModel
    {
        private readonly IMembershipService _membershipService;
        public IndexModel(IMembershipService membershipService)
        {
            _membershipService = membershipService;
        }

        public IList<MembershipView> Memberships { get; set; } = default!;
        public string StudentId;

        public async Task OnGetAsync()
        {
            StudentId = HttpContext.Session.GetString("studentId");
            Guid studentId = Guid.Parse(StudentId!);
            var memberships = await _membershipService.GetAllClubsOfStudentHasJoined(studentId);
            if (memberships.Count > 0)
            {
                Memberships = memberships;
            }
            else
            {
                TempData["error"] = "You have join no clubs!";
            }

        }
    }
}
