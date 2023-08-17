using System;
using System.Collections.Generic;

namespace ClubManagementRepositories.Models
{
    public partial class ClubBoard:BaseEntity
    {
        public ClubBoard()
        {
            MemberClubBoards = new HashSet<MemberClubBoard>();
        }

        public Guid ClubBoardId { get; set; }=Guid.NewGuid();
        public string? ClubBoardName { get; set;}
        public Guid? ClubId { get; set; }
        public string? Status { get; set; } = "Active";
        public virtual Club? Club { get; set; }
        public virtual ICollection<MemberClubBoard> MemberClubBoards { get; set; }
    }
}
