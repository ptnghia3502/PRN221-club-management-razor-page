using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClubManagementServices.ViewModels
{
    public class ClubActivityCreateView
    {
        public Guid? ClubId { get; set; }
        public string? ActivityName { get; set; }
        public string? Description { get; set; }
        public string? Type { get; set; }
        public DateTime? StartDate { get; set; }
        public DateTime? EndDate { get; set; }
        public string? Location { get; set; }
    }
    public class ClubActivityUpdateView
    {
        public Guid ActivityId { get; set; }
        public Guid? ClubId { get; set; }
        public string? ActivityName { get; set; }
        public string? Description { get; set; }
        public string? Type { get; set; }
        public DateTime? StartDate { get; set; }
        public DateTime? EndDate { get; set; }
        public string? Location { get; set; }
        public string? Status { get; set; }
    }
}
