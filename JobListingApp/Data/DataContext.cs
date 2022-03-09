using JobListingApp.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace JobListingApp.Data
{
    public class DataContext : IdentityDbContext<User>
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options) { }

        public DbSet<Job> Jobs { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<UserJob> UsersJobs { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            builder.Entity<UserJob>()
            .HasKey(uj => new { uj.UserId, uj.JobId  });

            builder.Entity<UserJob>()
            .HasOne(u => u.User).WithMany(us => us.UserJobs)
            .HasForeignKey(f => f.UserId);

            builder.Entity<UserJob>()
            .HasOne(u => u.Job).WithMany(us => us.UserJobs)
            .HasForeignKey(f => f.JobId);
        }
    }
}
