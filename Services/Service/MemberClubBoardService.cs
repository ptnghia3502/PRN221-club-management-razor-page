using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using AutoMapper.Execution;
using ClubManagementRepositories.Models;
using ClubManagementServices.Interfaces;
using ClubManagementServices.ViewModels;

namespace ClubManagementServices.Service
{
    public class MemberClubBoardService : IMemberClubBoardService
    {
        private readonly IUnitOfWork _unitOfWork;

        private readonly IMapper _mapper;
        public MemberClubBoardService(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _mapper = mapper;
            _unitOfWork = unitOfWork;
        }

        public async Task<bool> AddMemberToClubBoard(MemberClubBoardCreateView createView)
        {

            var memberClubBoard = new MemberClubBoard
            {
                MemberClubBoardId = Guid.NewGuid(),
                ClubBoardId = createView.ClubBoardId,
                MembershipId = createView.MembershipId,
                FromDate = DateTime.Now,
                ToDate=createView.ToDate,
                Role = createView.Role,
                Status = "Active"

            };
            await _unitOfWork.MembershipClubBoardRepository.AddAsync(memberClubBoard);
            return await _unitOfWork.SaveChangeAsync() > 0;
        }

        public async Task<List<MemberClubBoardView>> GetAllMemberInClubBoardByClubBoardId(Guid clubBoardId)
        {
            var members = await _unitOfWork.MembershipClubBoardRepository.FindListByField(x => x.IsDeleted == false && x.ClubBoardId == clubBoardId, x => x.Membership!, x => x.Membership!.Student!);
            var result = _mapper.Map<List<MemberClubBoardView>>(members);
            return result;
        }

        public async Task<List<MemberOption>> GetAllMemberOutClubBoardByClubBoardId(Guid clubBoardId)
        {
            var memberIn = await GetAllMemberInClubBoardByClubBoardId(clubBoardId);
            var listId= memberIn.Select(x=>x.MembershipId).ToList();
            var members = await _unitOfWork.MembershipRepository.FindListByField(x => !listId.Contains(x.MembershipId) && x.IsDeleted==false,x=>x.Student!);
            var result = _mapper.Map<List<MemberOption>>(members);
            return result;
        }

        public async Task<List<string>> GetRoleOfMemberInClub(Guid studentId,Guid clubId)
        {
            var member= await _unitOfWork.MembershipRepository
                .FindByField(x=>x.StudentId==studentId
                             && x.IsDeleted==false
                             && x.ClubId==clubId);
            if (member == null)
            {
                return null;
            }
            var memberClub = await _unitOfWork.MembershipClubBoardRepository.FindListByField(x => x.MembershipId == member.MembershipId);
            return memberClub!.Select(x=>x.Role!).ToList();
        }
    }
}
