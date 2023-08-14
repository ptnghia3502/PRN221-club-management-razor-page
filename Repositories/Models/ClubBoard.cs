using System;
using System.Collections.Generic;

namespace ClubManagementRepositories.Models
{
    public partial class ClubBoard
    {
        public ClubBoard()
        {
            MemberClubBoards = new HashSet<MemberClubBoard>();
        }

        public Guid ClubBoardId { get; set; }
        public string? ClubBoardName { get; set; }
        public Guid? ClubId { get; set; }
        public string? Status { get; set; }
        public DateTime? CreateAt { get; set; }
        public virtual Club? Club { get; set; }
        public virtual ICollection<MemberClubBoard> MemberClubBoards { get; set; }
    }
}
