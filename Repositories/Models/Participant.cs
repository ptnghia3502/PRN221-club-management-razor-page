using System;
using System.Collections.Generic;

namespace ClubManagementRepositories.Models
{
    public partial class Participant:BaseEntity
    {
        public Guid ParticipantId { get; set; }=Guid.NewGuid();
        public Guid? MembershipId { get; set; }
        public Guid? ActivityId { get; set; }
        public DateTime? JoinedDate { get; set; } = DateTime.Now;
        public bool? IsJoined { get; set; } = true;
        public string? Status { get; set; }

        public virtual ClubActivity? Activity { get; set; }
        public virtual Membership? Membership { get; set; }
    }
}
