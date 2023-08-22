using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClubManagementServices.ViewModels
{
    public class ParticipantView
    {
        public string? MemberName { get; set; } 
        public string? ActivityName { get; set; }
        public Guid? ActivityId { get; set; }
        public Guid ParticipantId { get; set; }
        public string? Status { get; set; }
        public DateTime? JoinedDate { get; set; } = DateTime.Now;
    }

    public class ParticipantCreateView
    {
        public Guid? MembershipId { get; set; }
        public Guid? ActivityId { get; set; }
        public string? Status { get; set; }
    }
    public class ParticipantUpdateView
    {
        public Guid ParticipantId { get; set; }
        public string? Status { get; set; }
    }
}
