using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity;
using Marketify.DataAccess.Concrete.EntityFramework;
using Marketify.Entity.Identity;


namespace Marketify.Api.SeedData
{
    public class SeedData
    {
      
            public static void Initialize(IServiceProvider serviceProvider)
            {
                var context = serviceProvider.GetService<IdentityContext>();

                string[] roles = new string[] { "Admin","Customer" };

                foreach (string role in roles)
                {
                    var roleStore = new RoleStore<IdentityRole>(context);

                    if (!context.Roles.Any(r => r.Name == role))
                    {
                        roleStore.CreateAsync(new IdentityRole(role));
                    }
                }


                var user1 = new User
                {
                   
                    Email = "admin@info.com",
                    NormalizedEmail = "ADMIN@INFO.COM",
                    UserName = "Admin",
                    NormalizedUserName = "ADMIN",
                    PhoneNumber = "+111111111111",
                    EmailConfirmed = true,
                    PhoneNumberConfirmed = true,
                    SecurityStamp = Guid.NewGuid().ToString("D")
                };
             var user2 = new User
            {

                Email = "customer@info.com",
                NormalizedEmail = "CUSTOMER@INFO.COM",
                UserName = "Customer",
                NormalizedUserName = "CUSTOMER",
                PhoneNumber = "+111111111111",
                EmailConfirmed = true,
                PhoneNumberConfirmed = true,
                SecurityStamp = Guid.NewGuid().ToString("D")
            };


            if (!context.Users.Any(u => u.UserName == user1.UserName))
                {
                    var password = new PasswordHasher<User>();
                    var hashed = password.HashPassword(user1, "secret");
                    user1.PasswordHash = hashed;

                    var userStore = new UserStore<User>(context);
                    var result = userStore.CreateAsync(user1);

                }

                AssignRoles(serviceProvider, user1.Email, roles);

                context.SaveChangesAsync();
            }

            public static async Task<IdentityResult> AssignRoles(IServiceProvider services, string email, string[] roles)
            {
                UserManager<User> _userManager = services.GetService<UserManager<User>>();
                User user = await _userManager.FindByNameAsync(email);
                var result = await _userManager.AddToRoleAsync(user, roles[0]);
                 var result2 = await _userManager.AddToRoleAsync(user, roles[1]);
                return result;
            }

        }
    }

