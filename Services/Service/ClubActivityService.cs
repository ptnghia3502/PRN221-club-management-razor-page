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
    public class ClubActivityService : IClubActivityService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public ClubActivityService(IUnitOfWork unitOfWork,IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<bool> CreateActivity(ClubActivityCreateView createView)
        {
            var createDTO = _mapper.Map<ClubActivity>(createView);
            await _unitOfWork.ClubActivityRepository.AddAsync(createDTO);
            return await _unitOfWork.SaveChangeAsync()>0;
        }

        public async Task<bool> Delete(Guid id)
        {
            var activity= await _unitOfWork.ClubActivityRepository.FindByField(x => x.ActivityId == id && x.IsDeleted == false);
            activity.IsDeleted = true;
            _unitOfWork.ClubActivityRepository.Update(activity);
            return await _unitOfWork.SaveChangeAsync() > 0;
        }

        public async Task<ClubActivity> GetActivityById(Guid id)
        {
            return await _unitOfWork.ClubActivityRepository.FindByField(x=>x.ActivityId==id&& x.IsDeleted==false);

        }

        public async Task<ClubActivityUpdateView> GetActivityUpdateViewById(Guid id)
        {
            var activity = await _unitOfWork.ClubActivityRepository.FindByField(x => x.ActivityId == id && x.IsDeleted == false);
            return _mapper.Map<ClubActivityUpdateView>(activity);  
        }

        public async Task<List<ClubActivity>> GetAllActivitiesByClubId(Guid clubId)
        {
            return await _unitOfWork.ClubActivityRepository.FindListByField(x=>x.ClubId == clubId&& x.IsDeleted==false);
        }

        public async Task<bool> UpdateActivity(ClubActivityUpdateView updateView)
        {
           var activity= await GetActivityById(updateView.ActivityId);
           var updateDTO = _mapper.Map(updateView, activity);
           _unitOfWork.ClubActivityRepository.Update(updateDTO);
            return await _unitOfWork.SaveChangeAsync()>0;
        }
    }
}
