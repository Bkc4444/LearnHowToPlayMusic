using Microsoft.AspNetCore.Identity;
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
    }
}
