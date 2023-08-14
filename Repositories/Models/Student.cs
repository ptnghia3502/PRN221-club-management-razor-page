using System;
using System.Collections.Generic;

namespace ClubManagementRepositories.Models
{
    public partial class Student
    {
        public Student()
        {
            Memberships = new HashSet<Membership>();
        }

        public Guid StudentId { get; set; }=Guid.NewGuid();
        public string? StudentName { get; set; }
        public string? StudentCardId { get; set; }
        public string? Email { get; set; }
        public string? Phone { get; set; }
        public string? Gender { get; set; }
        public DateTime? Birthday { get; set; }
        public Guid? GradeId { get; set; }
        public Guid? MajorId { get; set; }
        public string? AvatarName { get; set; }
        public string? AvatarUrl { get; set; }
        public string? Status { get; set; } = "Active";
        public DateTime? CreateAt { get; set; }

        public virtual Grade? Grade { get; set; }
        public virtual Major? Major { get; set; }
        public virtual ICollection<Membership> Memberships { get; set; }
    }
}
