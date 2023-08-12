using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ClubManagementRepositories.Interfaces;
using ClubManagementRepositories.Models;

namespace ClubManagementRepositories.Repository
{
    public class ClubBoardRepo : GenericRepo<ClubBoard>, IClubBoardRepo
    {
        public ClubBoardRepo(ClubManagementContext context) : base(context)
        {
        }
    }
}
