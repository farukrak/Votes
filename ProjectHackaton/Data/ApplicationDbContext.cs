using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Votes.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Votes.ViewModels;

namespace Votes.Data
{
    public class ApplicationDbContext : IdentityDbContext<Employee>
    {
        public ApplicationDbContext(DbContextOptions options)
            : base(options) { }
        public DbSet<Employee> Employees { get; set; }
        public DbSet<Score> Scores { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            var employeeBuilder = modelBuilder.Entity<Employee>();
            employeeBuilder.Property(x => x.FirstName).IsRequired();
            employeeBuilder.Property(x => x.LastName).IsRequired();
            employeeBuilder.HasIndex(x => x.Email).IsUnique();

            var scoreBuilder = modelBuilder.Entity<Score>();
            scoreBuilder.Property(x => x.EmployeeId).IsRequired();
            scoreBuilder.HasIndex(x => x.Id).IsUnique();
        }
        public DbSet<Votes.ViewModels.ScoreViewModel> ScoreViewModel { get; set; }
    }
}
