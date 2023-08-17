using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ClubManagementServices.ViewModels;

namespace ClubManagementServices.Interfaces
{
    public interface IClubService
    {
        Task<List<ClubView>> GetAllClubs();
        Task<ClubView> GetClubById(Guid id);
        Task<bool> CreateClub(ClubCreateView createDTO);

        Task<ClubUpdateView> GetUpdateInfor(Guid id);
        Task<bool> UpdateClub (ClubUpdateView updateDTO);
    }
}
