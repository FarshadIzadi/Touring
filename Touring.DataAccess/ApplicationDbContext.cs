using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using Touring.Models;

namespace Touring.DataAccess
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public DbSet<ApplicationUser> ApplicationUser { get; set; }
        public DbSet<Accommodation> Accommodation { get; set; }
        public DbSet<Activity> Activity { get; set; }
        public DbSet<Trip> Trip { get; set; }
        public DbSet<TourHeader> TourHeader { get; set; }
        public DbSet<TourDetails> TourDetails { get; set; }
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {

        }


    }
}
