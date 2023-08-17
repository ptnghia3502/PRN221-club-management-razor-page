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
    public class ClubBoardService : IClubBoardService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        public ClubBoardService(IUnitOfWork unitOfWork,IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<bool> CreateClubBoard(ClubBoardCreateView createDTO)
        {
            var newClubBoard=_mapper.Map<ClubBoard>(createDTO);
            await _unitOfWork.ClubBoardRepository.AddAsync(newClubBoard);
            return await _unitOfWork.SaveChangeAsync()>0;
        }

        public async Task<List<ClubBoardView>> GetAllClubBoardByClubId(Guid clubId)
        {
            var cluboards= await _unitOfWork.ClubBoardRepository.FindListByField(x=>x.ClubId==clubId);
            var result= _mapper.Map<List<ClubBoardView>>(cluboards);
            return result;
        }

        public Task<ClubBoardView> GetClubBoardByClubId(Guid id)
        {
            throw new NotImplementedException();
        }
    }
}
