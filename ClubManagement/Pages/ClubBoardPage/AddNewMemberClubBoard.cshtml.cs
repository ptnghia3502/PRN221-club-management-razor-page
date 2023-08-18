using ClubManagementRepositories.Models;
using ClubManagementServices.Interfaces;
using ClubManagementServices.Service;
using ClubManagementServices.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace ClubManagement.Pages.ClubBoardPage
{
    public class AddNewMemberClubBoardModel : PageModel
    {
        private readonly IMemberClubBoardService _memberClubBoardService;
        private readonly IClubBoardService _clubBoardService;

        public AddNewMemberClubBoardModel(IMemberClubBoardService memberClubBoardService, IClubBoardService clubBoardService)
        {
            _memberClubBoardService = memberClubBoardService;
            _clubBoardService = clubBoardService;
        }

        [BindProperty]
        public Guid ClubBoardId { get; set; } = default;

        public IActionResult OnGet(Guid id)
        {
            ClubBoardId = id;
            return Page();
        }

        [BindProperty]
        public MemberClubBoardCreateView MemberClubBoard { get; set; } = default!;


        public async Task<IActionResult> OnPostAsync()
        {
            await _memberClubBoardService.AddMemberToClubBoard(MemberClubBoard);
            return RedirectToPage("./Details", new { id = ClubBoardId });
        }
    }
}
