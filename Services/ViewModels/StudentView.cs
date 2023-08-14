using ClubManagementRepositories.Models;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClubManagementServices.ViewModels
{
    public class StudentView
    {
        public Guid StudentId { get; set; }
        public string? StudentName { get; set; }
        public string? StudentCardId { get; set; }
        public string? Email { get; set; }
        public string? Phone { get; set; }
        public string? Gender { get; set; }
        public DateTime? Birthday { get; set; }
        public virtual Grade? Grade { get; set; }
        public virtual Major? Major { get; set; }
        public string? AvatarUrl { get; set; }
    }

    public class StudentCreateView
    {
       
        public string? StudentName { get; set; }
        public string? StudentCardId { get; set; }
        public string? Email { get; set; }
        public string? Phone { get; set; }
        public string? Gender { get; set; }
        public DateTime? Birthday { get; set; }
        public Guid? GradeId { get; set; }
        public Guid? MajorId { get; set; }
        public IFormFile? Avatar { get; set; }
    }

    public class StudentUpdateView
    {
        public Guid StudentId { get; set; }
        public string? StudentName { get; set; }
        public string? StudentCardId { get; set; }
        public string? Email { get; set; }
        public string? Phone { get; set; }
        public string? Gender { get; set; }
        public DateTime? Birthday { get; set; }
        public Guid? GradeId { get; set; }
        public Guid? MajorId { get; set; }
        public IFormFile? Avatar { get; set; }
    }
}
