using ClubManagementRepositories.Models;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClubManagementServices.ViewModels
{
    public class MembershipView
    {
        public Guid MembershipId { get; set; }
        public string? CardMemberUrl { get; set; }
        public DateTime? JoinDate { get; set; }
        public DateTime? OutDate { get; set; }
        public string? Status { get; set; }
        public virtual Student? Student { get; set; }
    }

    public class MembershipCreateView
    {
        public Guid ClubId { get; set; }
        public string? StudentEmail { get; set; }
        public IFormFile? CardMemberUrl { get; set; }
        public Guid? ClubBoardId { get; set; }
    }

    public class MembershipUpdateView
    {
        public Guid MembershipId { get; set; }
        public IFormFile? CardMemberUrl { get; set; }
        public string? Status { get;set; }
    }
}
