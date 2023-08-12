using System;
using System.Collections.Generic;

namespace ClubManagementRepositories.Models
{
    public partial class Participant
    {
        public Guid ParticipantId { get; set; }
        public Guid? MembershipId { get; set; }
        public Guid? ActivityId { get; set; }
        public DateTime? JoinedDate { get; set; }
        public bool? IsJoined { get; set; }

        public virtual ClubActivity? Activity { get; set; }
        public virtual Membership? Membership { get; set; }
    }
}
