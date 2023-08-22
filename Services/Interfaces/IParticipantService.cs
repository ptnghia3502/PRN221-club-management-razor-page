using ClubManagementServices.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClubManagementServices.Interfaces
{
    public interface IParticipantService
    {
        Task<List<ParticipantView>> GetAllParticipantByActivityId(Guid activityId);

        Task<List<MemberOption>> GetAllMemberNotJoined(Guid activiyId);
        Task<bool> Create(ParticipantCreateView view);

        Task<ParticipantUpdateView> GetParticipantUpdateView(Guid participantId);
        Task<bool> Update(ParticipantUpdateView view);

        Task<ParticipantView> GetParticipantViewById(Guid participantId);

        Task<bool> Delete(Guid participantId);
    }
}
