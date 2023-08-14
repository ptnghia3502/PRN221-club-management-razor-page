using System;
using System.Collections.Generic;

namespace ClubManagementRepositories.Models
{
    public partial class Grade
    {
        public Grade()
        {
            Students = new HashSet<Student>();
        }

        public Guid GradeId { get; set; }
        public string? GradeName { get; set; }
        public DateTime? StartDate { get; set; }
        public DateTime? EndDate { get; set; }
        public DateTime? CreateAt { get; set; }
        public virtual ICollection<Student> Students { get; set; }
    }
}
