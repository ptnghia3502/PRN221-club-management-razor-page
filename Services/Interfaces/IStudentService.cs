using ClubManagementServices.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClubManagementServices.Interfaces
{
    public interface IStudentService
    {
        Task<List<StudentView>> GetAllStudents();
        Task<StudentView> GetStudentById(Guid id);
        Task<bool> CreateStudent(StudentCreateView createDTO);

        Task<StudentUpdateView> GetUpdateInfor(Guid id);

        Task<bool> Update(StudentUpdateView updateDTO);

    }
}
