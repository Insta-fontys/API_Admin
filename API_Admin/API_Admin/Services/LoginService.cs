using API_Admin.Security;
using DataAccesLibrary.Dto;
using Microsoft.AspNetCore.Identity;
using System.Linq;
using System.Threading.Tasks;

namespace API_Admin.Services
{
    public class LoginService
    {
        private readonly UserManager<IdentityUser> userManager;
        private readonly SignInManager<IdentityUser> signInManager;

        public LoginService(UserManager<IdentityUser> userManager, SignInManager<IdentityUser> signInManager)
        {
            this.userManager = userManager;
            this.signInManager = signInManager;
        }

        public async Task<string> Authenticate(LoginModel loginModel)
        {
            var user = await userManager.FindByEmailAsync(loginModel.Email);
            var result = await signInManager.PasswordSignInAsync(user, loginModel.Password, false, false);
            var roles = await userManager.GetRolesAsync(user);

            if(roles.Contains("admin"))
            {
                if (result.Succeeded)
                    return JwtAuthenticationManager.GenerateJwtToken(user, roles.First());
            }
            return null;
        }
    }
}
