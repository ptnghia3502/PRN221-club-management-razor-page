using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ClubManagementRepositories.Interfaces;
using ClubManagementRepositories.Models;

namespace ClubManagementRepositories.Repository
{
    public class StudentRepo : GenericRepo<Student>, IStudentRepo
    {
        public StudentRepo(ClubManagementContext context) : base(context)
        {
        }
    }
}
