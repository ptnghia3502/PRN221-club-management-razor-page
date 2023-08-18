using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ClubManagementRepositories.Models;

namespace ClubManagementServices.ViewModels
{
    public class MemberClubBoardView
    {
        public Guid MemberClubBoardId { get; set; }
        public Guid? ClubBoardId { get; set; }
        public Guid? MembershipId { get; set; }
        public DateTime? FromDate { get; set; }
        public DateTime? ToDate { get; set; }
        public string? Role { get; set; }
        public string? Status { get; set; }

        public virtual ClubBoard? ClubBoard { get; set; }
        public virtual Membership? Membership { get; set; }
    }
}
