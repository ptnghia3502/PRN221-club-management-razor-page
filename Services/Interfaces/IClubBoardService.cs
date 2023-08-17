using ClubManagementRepositories.Models;
using ClubManagementServices.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClubManagementServices.Interfaces
{
    public interface IClubBoardService
    {
        Task<List<ClubBoardView>> GetAllClubBoardByClubId(Guid clubId);
        Task<ClubBoardView> GetClubBoardByClubId(Guid id);
        Task<bool> CreateClubBoard(ClubBoardCreateView createDTO);
        Task<bool> UpdateClubBoard(ClubBoardUpdateView updateDTO);
        Task<ClubBoardView> GetClubBoardById(Guid id);

    }
}
