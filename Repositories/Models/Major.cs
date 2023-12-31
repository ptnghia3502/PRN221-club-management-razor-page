﻿using System;
using System.Collections.Generic;

namespace ClubManagementRepositories.Models
{
    public partial class Major:BaseEntity
    {
        public Major()
        {
            Students = new HashSet<Student>();
        }

        public Guid MajorId { get; set; }
        public string? MajorName { get; set; }
        public virtual ICollection<Student> Students { get; set; }
    }
}
