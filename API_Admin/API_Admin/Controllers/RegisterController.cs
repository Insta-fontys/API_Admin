using DataAccesLibrary.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using System.Threading.Tasks;
using API_Admin.Services;
using DataAccesLibrary.Dto;

namespace API_Admin.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [AllowAnonymous]
    public class RegisterController : ControllerBase
    {
        private readonly RegistrationService registrationService;

        public RegisterController(RegistrationService registrationService)
        {
            this.registrationService = registrationService;
        }

        [HttpPost]
        public async Task<bool> PostAdminAccount(RegisterModel registerModel)
        {
            if (await registrationService.PostAdminAccount(registerModel))
                return true;

            return false;
        }
    }
}
