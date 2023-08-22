using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using ClubManagementRepositories.Models;
using ClubManagementServices.Interfaces;
using ClubManagementServices.ViewModels;

namespace ClubManagementServices.Service
{
    public class ParticipantService : IParticipantService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        public ParticipantService(IUnitOfWork unitOfWork,IMapper mapper)
        {
            _mapper = mapper;
            _unitOfWork = unitOfWork;
        }

        public async Task<bool> Create(ParticipantCreateView view)
        {
            var par= _mapper.Map<Participant>(view);
            await _unitOfWork.ParticipantRepository.AddAsync(par);
            return await _unitOfWork.SaveChangeAsync() > 0;
        }

        public async Task<bool> Delete(Guid participantId)
        {
            var participant = await _unitOfWork.ParticipantRepository.FindByField(x => x.ParticipantId == participantId && x.IsDeleted == false, x => x.Activity!);
            participant.IsDeleted=true;
            _unitOfWork.ParticipantRepository.Update(participant);
            return await _unitOfWork.SaveChangeAsync()>0;
        }

        public async Task<List<MemberOption>> GetAllMemberNotJoined(Guid activiyId)
        {
            var activity= await _unitOfWork.ClubActivityRepository.FindByField(x=>x.ActivityId==activiyId&&x.IsDeleted==false);
            var participants= await _unitOfWork.ParticipantRepository.FindListByField(x=>x.ActivityId==activiyId&&x.IsDeleted==false);
            var listId=  participants.Select(x=>x.MembershipId).ToList();
            var members = await _unitOfWork.MembershipRepository.FindListByField(x => !listId.Contains(x.MembershipId) && x.ClubId == activity.ClubId &&x.IsDeleted==false,x=>x.Student!);
            var result= _mapper.Map<List<MemberOption>>(members);
            return result;
        }

        public async Task<List<ParticipantView>> GetAllParticipantByActivityId(Guid activityId)
        {
            var par=await _unitOfWork.ParticipantRepository.FindListByField(x=>x.ActivityId == activityId&&x.IsDeleted==false,x=>x.Membership!,x=>x.Activity!);
            var result= _mapper.Map<List<ParticipantView>>(par);
            for (var i = 0; i < result.Count; i++)
            {
                var student = await _unitOfWork.StudentRepository.FindByField(x => x.StudentId == par[i].Membership!.StudentId&& x.IsDeleted == false);
                result[i].MemberName = student.StudentName;
                result[i].ActivityName = par[i].Activity!.ActivityName;
            }
            return result;
        }

        public async Task<ParticipantUpdateView> GetParticipantUpdateView(Guid participantId)
        {
            var participant= await _unitOfWork.ParticipantRepository.FindByField(x=>x.ParticipantId == participantId&&x.IsDeleted==false);
            return _mapper.Map<ParticipantUpdateView>(participant);
        }

        public async Task<ParticipantView> GetParticipantViewById(Guid participantId)
        {
            var participant = await _unitOfWork.ParticipantRepository.FindByField(x => x.ParticipantId == participantId && x.IsDeleted == false,x=>x.Activity!);
            var member= await _unitOfWork.MembershipRepository.FindByField(x=>x.MembershipId==participant.MembershipId&&x.IsDeleted==false,x=>x.Student!);
            var result= _mapper.Map<ParticipantView>(participant);
            result.ActivityName = participant.Activity!.ActivityName;
            result.MemberName = member.Student!.StudentName;
            return result;
        }

        public async Task<bool> Update(ParticipantUpdateView view)
        {
            var participant = await _unitOfWork.ParticipantRepository.FindByField(x => x.ParticipantId == view.ParticipantId&&x.IsDeleted==false);
            participant = _mapper.Map(view, participant);
            _unitOfWork.ParticipantRepository.Update(participant);
            return await _unitOfWork.SaveChangeAsync() > 0;
        }
    }
}
