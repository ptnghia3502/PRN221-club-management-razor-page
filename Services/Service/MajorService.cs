using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ClubManagementRepositories.Models;
using ClubManagementServices.Interfaces;

namespace ClubManagementServices.Service
{
    public class MajorService : IMajorService
    {
        private readonly IUnitOfWork _unitOfWork;
        public MajorService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<List<Major>> GetAllMajor()
        {
           return await _unitOfWork.MajorRepository.GetAllAsync();
        }
    }
}
