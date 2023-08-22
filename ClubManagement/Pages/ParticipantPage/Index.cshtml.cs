using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using ClubManagementRepositories.Models;
using ClubManagementServices.ViewModels;
using ClubManagementServices.Interfaces;

namespace ClubManagement.Pages.ParticipantPage
{
    public class IndexModel : PageModel
    {
        private readonly IParticipantService _participantService;

        public IndexModel(IParticipantService participantService)
        {
            _participantService = participantService;
        }

        public IList<ParticipantView> Participant { get;set; } = default!;
        [BindProperty]
        public Guid ActivityId { get; set; } = default;
        public async Task OnGetAsync(Guid id)
        {
            ActivityId = id;
            Participant = await _participantService.GetAllParticipantByActivityId(id);
        }
    }
}
