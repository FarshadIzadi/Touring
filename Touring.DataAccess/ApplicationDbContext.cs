using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using Touring.Models;

namespace Touring.DataAccess
{
    public class ApplicationDbContext : IdentityDbContext<ApplicationUser,ApplicationRoles,string,IdentityUserClaim<string>,ApplicationUserRole,IdentityUserLogin<string>,IdentityRoleClaim<string>,IdentityUserToken<string>>
    {
        public DbSet<Meal> Meals { get; set; }
        public DbSet<ApplicationUser> ApplicationUser { get; set; }
        public DbSet<ApplicationRoles> ApplicationRoles { get; set; }
        public DbSet<ApplicationUserRole> ApplicationUserRole { get; set; }
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
