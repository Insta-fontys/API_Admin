using DataAccesLibrary.DataAccess;
using DataAccesLibrary.Models;
using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Identity;
using System.Linq;
using System.Security.Cryptography;
using System.Threading.Tasks;
using DataAccesLibrary.Dto;

namespace API_Admin.Services
{
    public class RegistrationService
    {
        private readonly IdentityRegistrationService identityRegistrationService;

        public RegistrationService(IdentityRegistrationService identityRegistrationService)
        {
            this.identityRegistrationService = identityRegistrationService;
        }

        public async Task<bool> PostAdminAccount(RegisterModel registerModel)
        {
            var user = new IdentityUser
            {
                Email = registerModel.Email.Trim(),
                UserName = registerModel.Username.Trim()
            };
            if (!await identityRegistrationService.DoesEmailExist(registerModel.Email))
                return false;
            if (await identityRegistrationService.CreateIdentityUser(user, "admin"))
                return true;
            return false;
        }
    }
}
