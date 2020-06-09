using System;
using System.Collections.Generic;
using System.Text;
using Diploma.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace Diploma.Data
{
    public sealed class ApplicationDbContext : IdentityDbContext<Employee, IdentityRole<int>, int>
    {
        public DbSet<Buyer> Buyers { get; set; }
        public DbSet<Contract> Contracts { get; set; }
        public DbSet<Employee> Employees { get; set; }
        public DbSet<House> Houses { get; set; }
        public DbSet<Seller> Sellers { get; set; }
        public DbSet<ContractType> ContractTypes { get; set; }
        public DbSet<PromotionHistory> PromotionHistories { get; set; }
        public DbSet<Degree> Degrees { get; set; }
      

        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Contract>()
                .HasOne(p => p.Seller)
                .WithMany(b => b.Contacts)
                .HasForeignKey(p => p.SellerId).OnDelete(DeleteBehavior.NoAction); 
            modelBuilder.Entity<Contract>()
                .HasOne(p => p.Employee)
                .WithMany(b => b.Contracts)
                .HasForeignKey(p => p.EmployeeId).OnDelete(DeleteBehavior.NoAction);

            modelBuilder.Entity<IdentityRole<int>>().HasData(new IdentityRole<int> {Id = 1, Name = "Admin", NormalizedName = "Admin".ToUpper() });
            modelBuilder.Entity<IdentityRole<int>>().HasData(new IdentityRole<int> {Id = 2, Name = "User", NormalizedName = "user".ToUpper() });

        }
    }
}
