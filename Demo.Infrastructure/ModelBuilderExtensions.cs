using Demo.Core.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Demo.Infrastructure
{
    public static class ModelBuilderExtensions
    {
        public static void Seed(this ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<RoleDTO>().HasData(
                new RoleDTO
                {
                    Id = 1,
                    Name = "Admin"
                },
                new RoleDTO
                {
                    Id = 2,
                    Name = "User"
                },
                new RoleDTO
                {
                    Id = 3,
                    Name = "Staff"
                }
            );
           
        }
    }
}
