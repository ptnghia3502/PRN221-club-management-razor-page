using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClubManagementRepositories.Models
{
    public class BaseEntity
    {
        public DateTime? CreateAt { get; set; } = DateTime.Now;
        public bool IsDeleted { get; set; }=false;
    }
}
