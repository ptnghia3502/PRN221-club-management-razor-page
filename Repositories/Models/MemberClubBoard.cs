using System;
using System.Collections.Generic;

namespace ClubManagementRepositories.Models
{
    public partial class MemberClubBoard
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
