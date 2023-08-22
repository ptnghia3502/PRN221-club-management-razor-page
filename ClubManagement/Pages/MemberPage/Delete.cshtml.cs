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

namespace ClubManagement.Pages.MemberPage
{
    public class DeleteModel : PageModel
    {

        private readonly IMembershipService _membershipService;
        public DeleteModel(IMembershipService membershipService)
        {
            _membershipService = membershipService;
        }

        [BindProperty]
        public MembershipView Membership { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var membership = await _membershipService.GetMemberById(id.Value);
            if (membership == null)
            {
                return NotFound();
            }
            else
            {
                Membership = membership;
            }
            return Page();
        }

        public async Task<IActionResult> OnPostAsync(Guid? id)
        {
            var membership = await _membershipService.GetMemberById(id!.Value);
            await _membershipService.Delete(id!.Value);
            return RedirectToPage("./Index", new {id=membership.Club!.ClubId});
        }
    }
}
