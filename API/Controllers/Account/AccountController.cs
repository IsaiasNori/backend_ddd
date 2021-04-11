
using System;
using System.Threading.Tasks;
using Domain.Interfaces.Services;
using Domain.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Api.Controllers
{
    [Route("api/v1/[controller]")]
    public class AccountController : BaseApiController
    {
        IUserService _userService;
        public AccountController(IUserService userService) : base()
        {
            _userService = userService;
        }

        [HttpGet]
        [AllowAnonymous]
        public async Task<ActionResult<dynamic>> Get()
        {

            var result = new { message = "Faz a porra do login" };

            return result;
        }


        [HttpPost]
        [AllowAnonymous]
        public async Task<ActionResult<UserModel>> Login([FromBody] UserModel dto)
        {

            if (String.IsNullOrEmpty(dto.Name) ||
                String.IsNullOrEmpty(dto.Password))
                return NotFound(new { message = "Usuário ou senha inválidos" });

            var result = _userService.Authenticate(dto);

            return result;
        }
    }
}