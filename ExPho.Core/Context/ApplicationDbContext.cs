using ExPhO.Core.Entities;
using Microsoft.AspNet.Identity.EntityFramework;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExPho.Core.Context
{
    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {
        public ApplicationDbContext()
            : base("DefaultConnection", throwIfV1Schema: false)
        {
        }

        public static ApplicationDbContext Create()
        {
            return new ApplicationDbContext();
        }

        public DbSet<Teacher> Teachers { get; set; }
        public DbSet<Learner> Learners { get; set; }
        public DbSet<Jury> Juries { get; set; }
        public DbSet<Visit> Visits { get; set; }
        public DbSet<Team> Teams { get; set; }
        public DbSet<Problem> Problems { get; set; }
    }
}
