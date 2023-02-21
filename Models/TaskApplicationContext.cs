
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace mission8.Models
{
    public class TaskApplicationContext : DbContext
    {
        //constructor
        public TaskApplicationContext(DbContextOptions<TaskApplicationContext> options) : base(options)
        {
            //leave blank for now
        }

        public DbSet<ApplicationResponse> Responses { get; set; }
        public DbSet<Category> Categories { get; set; }

        //seed data
        protected override void OnModelCreating(ModelBuilder mb)
        {
            mb.Entity<Category>().HasData
                (
                new Category { CategoryID = 1, CategoryName = "Home" },
                new Category { CategoryID = 2, CategoryName = "School" },
                new Category { CategoryID = 3, CategoryName = "Work" },
                new Category { CategoryID = 4, CategoryName = "Church" }
                );

            mb.Entity<ApplicationResponse>().HasData
                (
                    new ApplicationResponse
                    {
                        ApplicationID = 1,
                        Task = "Mission08 Project",
                        DueDate = "02-24-2023",
                        Quandrant = 2,
                        CategoryID = 2,
                        Completed = false,
                    }
                );
        }
    }
}
