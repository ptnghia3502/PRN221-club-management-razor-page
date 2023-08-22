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

namespace ClubManagement.Pages.ParticipantPage
{
    public class DeleteModel : PageModel
    {
        private readonly IParticipantService _participantService;

        public DeleteModel(IParticipantService participantService)
        {
            _participantService = participantService;
        }

        [BindProperty]
      public ParticipantView Participant { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(Guid? id)
        {
            Participant = await _participantService.GetParticipantViewById(id!.Value);
            return Page();
        }

        public async Task<IActionResult> OnPostAsync(Guid? id)
        {
            var par = await _participantService.GetParticipantViewById(id!.Value);
            await _participantService.Delete(id!.Value);
            
            return RedirectToPage("./Index", new {id=par.ActivityId});
        }
    }
}
