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
using ClubManagementServices.Service;

namespace ClubManagement.Pages.MemberPage
{
    public class CreateModel : PageModel
    {
        private readonly IMembershipService _membershipService;
        public CreateModel(IMembershipService membershipService)
        { 
            _membershipService = membershipService;
        }
        [BindProperty]
        public Guid ClubId { get; set; } = default;
        public IActionResult OnGet(Guid id)
        {
            ClubId = id;
            return Page();
        }

        [BindProperty]
        public MembershipCreateView Membership { get; set; } = default!;
        

        public async Task<IActionResult> OnPostAsync()
        {
            await _membershipService.CreateMember(Membership);

            return RedirectToPage("./Index", new {id=Membership.ClubId});
        }


    }
}
