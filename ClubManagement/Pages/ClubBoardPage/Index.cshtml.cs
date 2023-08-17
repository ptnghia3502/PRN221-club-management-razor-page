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

namespace ClubManagement.Pages.ClubBoardPage
{
    public class IndexModel : PageModel
    {
        private readonly IClubBoardService _clubBoardService;
        public IndexModel(IClubBoardService clubBoardService)
        {
            _clubBoardService = clubBoardService;
        }

        public IList<ClubBoardView> ClubBoard { get;set; } = default!;

        [BindProperty]
        public Guid ClubId { get; set; } = default;
        public async Task OnGetAsync(Guid id)
        {
            ClubId = id;
            var result= await _clubBoardService.GetAllClubBoardByClubId(id);
            if (result != null)
            {
                ClubBoard = result;
            }
        }
    }
}
