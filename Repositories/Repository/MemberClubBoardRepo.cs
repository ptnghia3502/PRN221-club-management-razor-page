using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ClubManagementRepositories.Interfaces;
using ClubManagementRepositories.Models;

namespace ClubManagementRepositories.Repository
{
    public class MemberClubBoardRepo : GenericRepo<MemberClubBoard>, IMemberClubBoardRepo
    {
        public MemberClubBoardRepo(ClubManagementContext context) : base(context)
        {
        }
    }
}
