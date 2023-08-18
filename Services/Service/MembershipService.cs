using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using ClubManagementRepositories.Models;
using ClubManagementServices.Common;
using ClubManagementServices.Interfaces;
using ClubManagementServices.ViewModels;

namespace ClubManagementServices.Service
{
    public class MembershipService : IMembershipService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public MembershipService(IUnitOfWork unitOfWork,IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<bool> CreateMember(MembershipCreateView createView)
        {
            var student = await _unitOfWork.StudentRepository.FindByField(x => x.Email == createView.StudentEmail && x.IsDeleted == false);
            if (student == null)
            {
                return false;
            }
            
            var member = new Membership
            {
                MembershipId=Guid.NewGuid(),
                ClubId=createView.ClubId,
                StudentId=student.StudentId,
                JoinDate=DateTime.Now,
                CreateAt=DateTime.Now,
                Status="Active"

            };
            var fileName= member.MembershipId.ToString()+ "_"+createView.CardMemberUrl!.FileName;
            var file = await createView.CardMemberUrl.UploadFileAsync(fileName);
            member.CardMemberUrl = file.URL;
            await _unitOfWork.MembershipRepository.AddAsync(member);
            return await _unitOfWork.SaveChangeAsync()>0;
        }

        public async Task<List<MembershipView>> GetAllClubsOfStudentHasJoined(Guid studentId)
        {
            var clubs = await _unitOfWork.MembershipRepository.FindListByField(x => x.IsDeleted == false && x.StudentId == studentId, x => x.Club!);
            var result = _mapper.Map<List<MembershipView>>(clubs);
            return result;
        }

        public async Task<List<MembershipView>> GetAllMemberByClubId(Guid clubid)
        {
            var members= await _unitOfWork.MembershipRepository.FindListByField(x=>x.IsDeleted==false&& x.ClubId==clubid,x=>x.Student!);
            var result= _mapper.Map<List<MembershipView>>(members);
            return result;
        }

        public async Task<MembershipView> GetMemberById(Guid membershipId)
        {
            var member = await _unitOfWork.MembershipRepository.FindByField(x => x.MembershipId == membershipId, x => x.Student!);
            var result = _mapper.Map<MembershipView>(member);
            return result;
        }
    }
}
