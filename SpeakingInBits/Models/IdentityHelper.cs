using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
#nullable disable
namespace LearnHowToPlayMusic.Models
{
    //this is how to build roles for student and instructor
    public class IdentityHelper
    {
        public const string Instructor = "Instructor";
        public const string Student = "Student";

        public static async Task CreateRoles(IServiceProvider provider, params string[] roles)
        {
            RoleManager<IdentityRole> roleManger = provider.GetService<RoleManager<IdentityRole>>();

            foreach (string role in roles)
            {
                //confirming a role exists
                bool doesRoleExists = await roleManger.RoleExistsAsync(role);
                if (!doesRoleExists)
                {
                    await roleManger.CreateAsync(new IdentityRole(role));
                }
            }
        }
        public static async Task CreateDefaultUser(IServiceProvider provider, string role)
        {
            //This is creating a user
            var userManager = provider.GetService<UserManager<IdentityUser>>();

            // If there are no users present make the default user
            int numUsers = (await userManager.GetUsersInRoleAsync(role)).Count;
            if (numUsers == 0)// if not users are in the specified role
            {
                var defaultUser = new IdentityUser()
                {
                    Email = "instuctor@learntoplaymusic.com",
                    UserName = "Admin"
                };

                // Hardcoding a password. DO NOT DO THIS
                await userManager.CreateAsync(defaultUser, "Programming1#");

                await userManager.AddToRoleAsync(defaultUser, role);
            }
        }
    }
}
