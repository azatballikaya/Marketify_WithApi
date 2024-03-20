using Marketify.Entity;
using Marketify.Entity.Identity;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;

namespace Marketify.DataAccess.Concrete.EntityFramework
{
    public class IdentityContext:IdentityDbContext<User,Role,string>
    {
        public IdentityContext(DbContextOptions<IdentityContext> options):base(options) 
        {
            
        }
        //protected override void OnModelCreating(ModelBuilder modelBuilder)
        //{
        //    base.OnModelCreating(modelBuilder);

        //    var role1Id = Guid.NewGuid().ToString();
        //    var user1Id = Guid.NewGuid().ToString();
        //    var user2Id = Guid.NewGuid().ToString();
        //    var role2Id = Guid.NewGuid().ToString();
        //    //Seeding a  'Administrator' role to AspNetRoles table
        //    modelBuilder.Entity<IdentityRole>().HasData(new IdentityRole { Id = role1Id, Name = "Admin", NormalizedName = "ADMIN".ToUpper() }
        //        ,new IdentityRole { Id= role2Id,Name="Customer",NormalizedName="CUSTOMER".ToUpper() }
            
        //    );


        //    //a hasher to hash the password before seeding the user to the db
        //    var hasher = new PasswordHasher<User>();
            

        //    //Seeding the User to AspNetUsers table
        //    modelBuilder.Entity<User>().HasData(
        //        new User
        //        {
        //            Id = user1Id, // primary key
        //            UserName = "admin",
        //            NormalizedUserName = "ADMIN",
        //            PasswordHash = hasher.HashPassword(null, "123456"),
        //            Job="Admin"
        //        },
        //         new User
        //         {
        //             Id = user2Id, // primary key
        //             UserName = "customer",
        //             NormalizedUserName = "CUSTOMER",
        //             PasswordHash = hasher.HashPassword(null, "123456"),
        //             Job="Admin"
        //         }
        //    );


        //    //Seeding the relation between our user and role to AspNetUserRoles table
        //    modelBuilder.Entity<IdentityUserRole<string>>().HasData(
        //        new IdentityUserRole<string>
        //        {
        //            RoleId=role1Id,
        //            UserId=user1Id,
        //        },
        //        new IdentityUserRole<string>
        //        {
        //            RoleId = role2Id,
        //            UserId=user2Id,
        //        }
        //    );


        //}
        public DbSet<Post> Posts { get; set; }
        public DbSet<Comment> Comments { get; set; }
        public DbSet<Like> Likes { get; set; }
        public DbSet<Offer> Offers { get; set; }
    }
}
