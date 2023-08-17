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
    public class IndexModel : PageModel
    {
        private readonly IMembershipService _membershipService;

        public IndexModel(IMembershipService membershipService)
        {
            _membershipService = membershipService;
        }

        public IList<MembershipView> Membership { get;set; } = default!;
        [BindProperty]
        public Guid ClubId { get; set; } = default;
        public async Task OnGetAsync(Guid id)
        {
            ClubId = id;
            var result = await _membershipService.GetAllMemberByClubId(id);
            if (result.Count>0)
            {
                Membership = result;
            }
        }
    }
}
