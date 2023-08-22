using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using ClubManagementRepositories.Models;
using ClubManagementServices.ViewModels;
using ClubManagementServices.Interfaces;

namespace ClubManagement.Pages.ParticipantPage
{
    public class EditModel : PageModel
    {
        private readonly IParticipantService _participantService;

        public EditModel(IParticipantService participantService)
        {
            _participantService = participantService;
        }

        [BindProperty]
        public ParticipantUpdateView Participant { get; set; } = default!;

        [BindProperty]
        public Guid ActivityId { get; set; }
        public async Task<IActionResult> OnGetAsync(Guid? id,Guid activityId)
        {
            ActivityId=activityId;
            Participant= await _participantService.GetParticipantUpdateView(id!.Value);
            return Page();
        }

        public async Task<IActionResult> OnPostAsync()
        {
            await _participantService.Update(Participant);
           return RedirectToPage("./Index", new {id=ActivityId});
        }

    }
}
