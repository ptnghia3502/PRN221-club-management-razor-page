using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ClubManagementRepositories.Models;
using Microsoft.AspNetCore.Http;

namespace ClubManagementServices.ViewModels
{
    public class ClubView
    {
        public Guid ClubId { get; set; }
        public string? ClubName { get; set; }
        public string? Description { get; set; }
        public string? Purpose { get; set; }
        public DateTime? CreatedDate { get; set; }
        public string? Status { get; set; }
        // public string? LogoName { get; set; }
        public string? LogoImageUrl { get; set; }
    }

    public class ClubCreateView
    {
        public string? ClubName { get; set; }
        public string? Description { get; set; }
        public string? Purpose { get; set; }
        public DateTime? CreatedDate { get; set; }
        public string? Status { get; set; }
        //public string? ChairmanEmail { get; set; }
        public IFormFile? LogoImage { get; set; }
    }

    public class ClubUpdateView
    {
        public Guid ClubId { get; set; }
        public string? ClubName { get; set; }
        public string? Description { get; set; }
        public string? Purpose { get; set; }
        public DateTime? CreatedDate { get; set; }
        public string? Status { get; set; }
        public IFormFile? LogoImage { get; set; }
    }
}
