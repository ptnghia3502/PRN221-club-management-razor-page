using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ClubManagementRepositories.Models;
using ClubManagementServices.ViewModels;

namespace ClubManagementServices.Interfaces
{
    public interface IMemberClubBoardService
    {
        Task<List<MemberClubBoardView>> GetAllMemberInClubBoardByClubBoardId(Guid clubId);
        Task<bool> AddMemberToClubBoard(MemberClubBoardCreateView createView);
        Task<List<MemberOption>> GetAllMemberOutClubBoardByClubBoardId(Guid clubId);

    }
}
