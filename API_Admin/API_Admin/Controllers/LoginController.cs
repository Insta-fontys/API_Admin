using API_Admin.Services;
using DataAccesLibrary.Dto;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API_Admin.Controllers
{        
    [Route("api/[controller]")]
    [ApiController]
    [AllowAnonymous]
    public class LoginController : ControllerBase
    {
        private readonly LoginService loginService;

        public LoginController(LoginService loginService)
        {
            this.loginService = loginService;
        }

        [HttpPost]
        public async Task<string> Login(LoginModel loginModel)
        {
            var result = await loginService.Authenticate(loginModel);
            if (result != null)
                return result;
            return null;
        }
    }
}
