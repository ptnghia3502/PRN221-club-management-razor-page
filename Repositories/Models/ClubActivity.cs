﻿using System;
using System.Collections.Generic;

namespace ClubManagementRepositories.Models
{
    public partial class ClubActivity:BaseEntity
    {
        public ClubActivity()
        {
            Participants = new HashSet<Participant>();
        }

        public Guid ActivityId { get; set; }=Guid.NewGuid();
        public Guid? ClubId { get; set; }
        public string? ActivityName { get; set; }
        public string? Description { get; set; }
        public string? Type { get; set; }
        public DateTime? StartDate { get; set; }
        public DateTime? EndDate { get; set; }
        public string? Location { get; set; }
        public string? Status { get; set; } = "UpComming";
        public virtual Club? Club { get; set; }
        public virtual ICollection<Participant> Participants { get; set; }
    }
}
