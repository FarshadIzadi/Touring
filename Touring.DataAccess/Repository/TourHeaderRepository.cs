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
    public class TourHeaderRepository : Repository<TourHeader>, ITourHeaderRepository
    {
        public TourHeaderRepository(DbContext db) : base(db)
        {
        }
    }
}
