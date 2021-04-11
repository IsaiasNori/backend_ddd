using System;
using System.Threading.Tasks;
using Domain.Interfaces.Services;
using Domain.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Api.Controllers
{
    [Route("api/v1/account")]
    public class HomeController : BaseApiController
    {
        IUserService _userService;
        public HomeController(IUserService userService) : base()
        {
            _userService = userService;
        }

        [HttpPost]
        [Route("login")]
        [AllowAnonymous]
        public async Task<ActionResult<UserModel>> Authenticate([FromBody] UserModel user)
        {

            if (String.IsNullOrEmpty(user.Name) ||
                String.IsNullOrEmpty(user.Password))
                return NotFound(new { message = "Usuário ou senha inválidos" });

            var result = _userService.Authenticate(user);

            return result;
        }
    }
}