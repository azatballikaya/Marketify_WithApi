using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity;
using Marketify.DataAccess.Concrete.EntityFramework;
using Marketify.Entity.Identity;


namespace Marketify.Api.SeedData
{
    public class SeedData
    {
      
            public static void Initialize(IServiceProvider service)
            {
            var context = service.GetService<IdentityContext>();

                string[] roles = new string[] { "Admin","Customer" };

               


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



                AssignRoles(service, user1.Email, roles[0]);
                AssignRoles(service, user2.Email, roles[1]);

                context.SaveChangesAsync();
            }

            public static async Task<IdentityResult> AssignRoles(IServiceProvider services, string email, string role)
            {
            UserManager<User> _userManager = services.GetService<UserManager<User>>();
            User user = await _userManager.FindByEmailAsync(email);
                var result = await _userManager.AddToRoleAsync(user, role);
                return result;
            }

        }
    }

