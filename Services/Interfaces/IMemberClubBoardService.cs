using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ClubManagementServices.ViewModels;

namespace ClubManagementServices.Interfaces
{
    public interface IMemberClubBoardService
    {
        Task<List<MemberClubBoardView>> GetAllMemberInClubBoardByClubBoardId(Guid clubId);
    }
}
