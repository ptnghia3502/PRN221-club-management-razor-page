using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ClubManagementRepositories.Models;
using ClubManagementServices.Interfaces;

namespace ClubManagementServices.Service
{
    public class GradeService : IGradeService
    {
        private readonly IUnitOfWork _unitOfWork;
        public GradeService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<List<Grade>> GetAllGrade()
        {
            return await _unitOfWork.GradeRepository.GetAllAsync();
        }
    }
}
