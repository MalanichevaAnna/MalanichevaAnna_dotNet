using Microsoft.AspNetCore.Identity;
using System.Threading.Tasks;

namespace TouristWebApp
{
    public class IdentityInitializer
    {
        public static async Task InitializeAsync(UserManager<IdentityUser> userManager, RoleManager<IdentityRole> roleManager)
        {
            string adminEmail = Constants.AdminEmail;
            string password = Constants.Password;
            if (await roleManager.FindByNameAsync(Constants.Admin) == null)
            {
                await roleManager.CreateAsync(new IdentityRole(Constants.Admin));
            }
            if (await roleManager.FindByNameAsync(Constants.Employee) == null)
            {
                await roleManager.CreateAsync(new IdentityRole(Constants.Employee));
            }
            if (await userManager.FindByNameAsync(adminEmail) == null)
            {
                var admin = new IdentityUser { Email = adminEmail, UserName = adminEmail };
                IdentityResult result = await userManager.CreateAsync(admin, password);
                if (result.Succeeded)
                {
                    await userManager.AddToRoleAsync(admin, Constants.Admin);
                }
            }
        }
    }
}