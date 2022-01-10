using API.Services;
using API.Utils;
using Microsoft.AspNetCore.Identity;
using System;
using System.Text;
using System.Threading.Tasks;

namespace API_Admin.Services
{
    public class IdentityRegistrationService
    {
        private readonly UserManager<IdentityUser> userManager;
        private readonly MailService mailService;
        private static PasswordGenerator generator = new PasswordGenerator();

        public IdentityRegistrationService(UserManager<IdentityUser> userManager, MailService mailService)
        {
            this.mailService = mailService;
            this.userManager = userManager;
        }

        public async Task<bool> DoesEmailExist(string email)
        {
            if (await userManager.FindByEmailAsync(email) != null)
                return false;
            return true;
        }

        public async Task<bool> CreateIdentityUser(IdentityUser user, string role)
        {
            var password = generator.GenerateRandomPassword();

            var result = await userManager.CreateAsync(user, password);

            if (result.Succeeded)
            {
                await userManager.AddToRoleAsync(user, role);
                mailService.SendUserCreatedMail(user.UserName, user.Email, password);
                return true;
            }
            return false;
        }
    }
}
