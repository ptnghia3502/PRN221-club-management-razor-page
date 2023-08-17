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
    public class ClubService : IClubService
    {
        private readonly IUnitOfWork _unitOfWork;

        private readonly IMapper _mapper;
        public ClubService(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _mapper = mapper;
            _unitOfWork = unitOfWork;
        }
        public async Task<bool> CreateClub(ClubCreateView createDTO)
        {
            var fileName = createDTO.ClubName + "_" + "Logo";
            var newClub = _mapper.Map<Club>(createDTO);
            var file = await createDTO.LogoImage!.UploadFileAsync(fileName);
            if (file != null)
            {
                newClub.LogoName = file.FileName;
                newClub.LogoImageUrl = file.URL;
                newClub.CreateAt = DateTime.Now;
                newClub.CreatedDate = DateTime.Now;
                newClub.Status = "Active";
            }
            await _unitOfWork.ClubRepository.AddAsync(newClub);

            return await _unitOfWork.SaveChangeAsync() > 0;
        }


        public async Task<List<ClubView>> GetAllClubs()
        {
            var clubs = await _unitOfWork.ClubRepository.GetAllAsync();
            var result = _mapper.Map<List<ClubView>>(clubs);
            return result;
        }

        public async Task<ClubView> GetClubById(Guid id)
        {
            var club = await _unitOfWork.ClubRepository.FindByField(x => x.ClubId == id);
            var result = _mapper.Map<ClubView>(club);
            return result;
        }

        public async Task<ClubUpdateView> GetUpdateInfor(Guid id)
        {
            var club = await _unitOfWork.ClubRepository.FindByField(x => x.ClubId == id);
            var result = _mapper.Map<ClubUpdateView>(club);
            return result;
        }

        public async Task<bool> UpdateClub(ClubUpdateView updateDTO)
        {
            var club = await _unitOfWork.ClubRepository.FindByField(x => x.ClubId == updateDTO.ClubId);
            string fileName = string.Empty;
            if (club == null)
            {
                return false;
            }
            if (updateDTO.LogoImage != null)
            {
                if (!string.IsNullOrEmpty(club.LogoName))
                {
                    await club.LogoName!.RemoveFileAsync();
                }
                fileName = updateDTO.ClubName + "_" + "Logo";
                var upload = await updateDTO.LogoImage!.UploadFileAsync(fileName);
                if (upload != null)
                {
                    club.LogoName = fileName;
                    club.LogoImageUrl = upload.URL;
                }
            }
            club = _mapper.Map(updateDTO, club);
            club.LogoName = fileName;
            _unitOfWork.ClubRepository.Update(club);
            return await _unitOfWork.SaveChangeAsync() > 0;
        }
    }
}
