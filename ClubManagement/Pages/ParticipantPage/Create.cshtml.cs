using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using ClubManagementRepositories.Models;
using ClubManagementServices.Interfaces;
using ClubManagementServices.ViewModels;

namespace ClubManagement.Pages.ParticipantPage
{
    public class CreateModel : PageModel
    {
        private readonly IParticipantService _participantService;

        public CreateModel(IParticipantService participantService)
        {
            _participantService = participantService;
        }
        [BindProperty]
        public Guid ActivityId { get; set; } = default;
        public async Task<IActionResult> OnGet(Guid id)
        {
            ActivityId = id;
            ViewData["MembershipId"] = new SelectList(await _participantService.GetAllMemberNotJoined(id), "MembershipId", "StudentName");
            return Page();
        }

        [BindProperty]
        public ParticipantCreateView Participant { get; set; } = default!;
        

        public async Task<IActionResult> OnPostAsync()
        {
            await _participantService.Create(Participant);

            return RedirectToPage("./Index", new {id=Participant.ActivityId});
        }
    }
}
