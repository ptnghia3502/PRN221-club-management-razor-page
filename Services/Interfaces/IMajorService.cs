﻿using ClubManagementRepositories.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClubManagementServices.Interfaces
{
    public interface IMajorService
    {
        Task<List<Major>> GetAllMajor();
    }
}
