using System;
using System.Collections.Generic;

namespace ClubManagementRepositories.Models
{
    public partial class Club
    {
        public Club()
        {
            ClubActivities = new HashSet<ClubActivity>();
            ClubBoards = new HashSet<ClubBoard>();
            Memberships = new HashSet<Membership>();
        }

        public Guid ClubId { get; set; }
        public string? ClubName { get; set; }
        public string? Description { get; set; }
        public string? Purpose { get; set; }
        public DateTime? CreatedDate { get; set; }
        public string? Status { get; set; }
        public string? LogoImageUrl { get; set; }

        public virtual ICollection<ClubActivity> ClubActivities { get; set; }
        public virtual ICollection<ClubBoard> ClubBoards { get; set; }
        public virtual ICollection<Membership> Memberships { get; set; }
    }
}
