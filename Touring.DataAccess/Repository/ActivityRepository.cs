﻿using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Touring.DataAccess.Repository.IRepository;
using Touring.Models;

namespace Touring.DataAccess.Repository
{
    public class ActivityRepository : Repository<Activity>, IActivityRepository
    {
        public ActivityRepository(DbContext db) : base(db)
        {
        }
    }
}
