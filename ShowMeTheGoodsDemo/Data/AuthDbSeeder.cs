using Microsoft.AspNetCore.Identity;
using ShowMeTheGoodsDemo.Auth.Model;

namespace Videogadon.Data
{
    public class AuthDbSeeder
    {
        private readonly UserManager<SiteRestUser> _userManager;
        private readonly RoleManager<IdentityRole> _roleManager;

        public AuthDbSeeder(UserManager<SiteRestUser> userManager, RoleManager<IdentityRole> roleManager)
        {
            _userManager = userManager;
            _roleManager = roleManager;
        }

        public async Task SeedAsync()
        {
            await AddDefaultRoles();
            await AddAdminUser();
        }

        private async Task AddAdminUser()
        {
            var newAdminUser = new SiteRestUser()
            {
                UserName = "admin",
                Email = "admin@admin.com"
            };

            var existingadminUser = await _userManager.FindByNameAsync(newAdminUser.UserName);
            if (existingadminUser == null)
            {
                var createAdminUserResult = await _userManager.CreateAsync(newAdminUser, "VerySafePassword1!");
                if (createAdminUserResult.Succeeded)
                {
                    await _userManager.AddToRolesAsync(newAdminUser, SiteRoles.All);
                }
            }

        }

        private async Task AddDefaultRoles()
        {
            foreach (var role in SiteRoles.All)
            {
                var roleExists = await _roleManager.RoleExistsAsync(role);
                if (!roleExists)
                    await _roleManager.CreateAsync(new IdentityRole(role));
            }
        }
    }
}
