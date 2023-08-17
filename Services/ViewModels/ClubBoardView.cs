using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClubManagementServices.ViewModels
{
    public class ClubBoardView
    {
        public Guid ClubBoardId { get; set; }
        public string? ClubBoardName { get; set; }
        public Guid? ClubId { get; set; }
        public string? Status { get; set; }
    }

    public class ClubBoardCreateView
    {
        public string? ClubBoardName { get; set; }
        public Guid? ClubId { get; set; }
    }
}
