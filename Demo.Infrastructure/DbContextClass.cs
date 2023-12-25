using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Demo.Core.Models;

namespace Demo.Infrastructure
{
    public class DbContextClass : DbContext
    {
        public DbContextClass(DbContextOptions<DbContextClass> contextOptions) : base(contextOptions)
        {

        }

        public DbSet<ProductDTO> Products { get; set; }

        public DbSet<RoleDTO> Roles { get; set; }

        public DbSet<ApplicationUserDTO> ApplicationUsers { get; set; }

        public DbSet<ApplicationUserToRoleDTO> ApplicationUserToRoles { get; set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // Configure many-to-many relationship
            modelBuilder.Entity<ApplicationUserToRoleDTO>()
                .HasKey(ur => new { ur.Id });

            modelBuilder.Entity<ApplicationUserToRoleDTO>()
                .HasOne(ur => ur.ApplicationUser)
                .WithMany(u => u.ApplicationUserToRoles)
                .HasForeignKey(ur => ur.UserId);

            modelBuilder.Entity<ApplicationUserToRoleDTO>()
                .HasOne(ur => ur.Role)
                .WithMany(r => r.ApplicationUserToRoles)
                .HasForeignKey(ur => ur.RoleId);

            // Additional configurations...

            base.OnModelCreating(modelBuilder);
        }

    }

}