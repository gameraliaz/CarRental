using CarRental.Application.Interfaces.Contexts;
using CarRental.Common;
using CarRental.Domain.Entities.User;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarRental.Persistence
{
    public class DataBaseContext : DbContext, IDataBaseContext
    {
        public DataBaseContext(DbContextOptions dbContextOptions) : base(dbContextOptions) { }
        public DbSet<User> Users { get; set; }
        public DbSet<Role> Roles { get; set; }
        public DbSet<UserInRole> UserInRoles { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Role>().HasData(new Role()
            {
                Id = Guid.NewGuid(),
                Name = nameof(UserRoles.Admin),
                Text = "مدیر",
                Color = "#0766AD",
            });
            modelBuilder.Entity<Role>().HasData(new Role()
            {
                Id = Guid.NewGuid(),
                Name = nameof(UserRoles.Renter),
                Text = "اجاره گیرنده",
                Color = "#C5E898",
            });
            modelBuilder.Entity<Role>().HasData(new Role()
            {
                Id = Guid.NewGuid(),
                Name = nameof(UserRoles.Rentor),
                Text = "اجاره دهنده",
                Color = "#29ADB2",
            });

            modelBuilder.Entity<Role>().HasIndex(u => u.Name).IsUnique();
            modelBuilder.Entity<User>().HasIndex(u => u.Phone).IsUnique();

            modelBuilder.Entity<User>().HasQueryFilter(u => !u.IsRemoved);
            modelBuilder.Entity<Role>().HasQueryFilter(u => !u.IsRemoved);
            modelBuilder.Entity<UserInRole>().HasQueryFilter(u => !u.IsRemoved);
        }
    }
}
