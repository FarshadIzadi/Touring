﻿using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Touring.DataAccess.Repository.IRepository;
using Touring.Models;

namespace Touring.DataAccess.Repository
{
    public class PaymentsRepository : Repository<Payments>, IPaymentsRepository
    {
        private readonly ApplicationDbContext _context;
        public PaymentsRepository(ApplicationDbContext context) : base(context)
        {
            _context = context;
        }


    }
}
