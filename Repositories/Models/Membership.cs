using System;
using System.Collections.Generic;

namespace ClubManagementRepositories.Models
{
    public partial class Membership:BaseEntity
    {
        public Membership()
        {
            MemberClubBoards = new HashSet<MemberClubBoard>();
            Participants = new HashSet<Participant>();
        }

        public Guid MembershipId { get; set; }=Guid.NewGuid();
        public Guid? ClubId { get; set; }
        public Guid? StudentId { get; set; }
        public string? CardMemberUrl { get; set; }
        public DateTime? JoinDate { get; set; }
        public DateTime? OutDate { get; set; }
        public string? Status { get; set; } = "Active";

        public virtual Club? Club { get; set; }
        public virtual Student? Student { get; set; }
        public virtual ICollection<MemberClubBoard> MemberClubBoards { get; set; }
        public virtual ICollection<Participant> Participants { get; set; }
    }
}
