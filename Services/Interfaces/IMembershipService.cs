using ClubManagementServices.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClubManagementServices.Interfaces
{
    public interface IMembershipService
    {
        Task<List<MembershipView>> GetAllMemberByClubId(Guid clubid);
        Task<bool> CreateMember(MembershipCreateView createView);
        Task<MembershipView> GetMemberById(Guid membershipId);
        Task<List<MembershipView>> GetAllClubsOfStudentHasJoined(Guid studentId);
    }
}
