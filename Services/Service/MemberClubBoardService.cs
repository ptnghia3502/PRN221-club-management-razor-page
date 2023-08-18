using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
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
        public async Task<List<MemberClubBoardView>> GetAllMemberInClubBoardByClubBoardId(Guid clubBoardId)
        {
            var members = await _unitOfWork.MembershipClubBoardRepository.FindListByField(x => x.IsDeleted == false, x => x.Membership!, x => x.Membership!.Student!);
            var result = _mapper.Map<List<MemberClubBoardView>>(members);
            return result;
        }
    }
}
