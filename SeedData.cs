using Marketify.Entity.Identity;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Marketify.DataAccess.SeedData
{
    public static class SeedData
    {
        public static void Seed(this ModelBuilder modelBuilder)
        {
            var adminRoleId = Guid.NewGuid().ToString();
            var customerRoleId = Guid.NewGuid().ToString();
            var adminId = Guid.NewGuid().ToString();
            var customerId = Guid.NewGuid().ToString();
           

            List<Role> roles = new List<Role>()
            {
                new Role { Id = adminRoleId, Name = "Admin", NormalizedName = "ADMIN" },
                new Role { Id = customerRoleId, Name = "Customer", NormalizedName = "CUSTOMER" },

            };
            modelBuilder.Entity<Role>().HasData(roles);
           

            List<User> users = new List<User>()
            {
                new User { Id = adminId, UserName = "admin", Job = "Admin",NormalizedUserName="ADMIN",NormalizedEmail="ADMIN@INFO.COM", IsApproved = true, Email = "admin@info.com", EmailConfirmed = true, PhoneNumber = "5555555555", PhoneNumberConfirmed = true },
                new User { Id = customerId, UserName = "customer", Job = "Customer",NormalizedUserName="CUSTOMER",NormalizedEmail="CUSTOMER@INFO.COM", IsApproved = true, Email = "customer@info.com", EmailConfirmed = true, PhoneNumber = "5555555555", PhoneNumberConfirmed = true },

            };
            PasswordHasher<User> passwordHasher = new PasswordHasher<User>();
            users[0].PasswordHash = passwordHasher.HashPassword(users[0], "Qwe123.");
            users[1].PasswordHash = passwordHasher.HashPassword(users[1], "Qwe123.");
            modelBuilder.Entity<User>().HasData(users);

            modelBuilder.Entity<IdentityUserRole<string>>().HasData(
                new IdentityUserRole<string> { UserId=adminId,RoleId=adminRoleId},
                new IdentityUserRole<string> { UserId=customerId,RoleId=customerRoleId}
                );
        }
    }
}
