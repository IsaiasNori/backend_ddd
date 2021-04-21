
using System;
using System.Threading.Tasks;
using Api.DTO.Login;
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
        public async Task<ActionResult<LoginResponseDTO>> Login([FromBody] LoginRequestDTO dto)
        {

            if (String.IsNullOrEmpty(dto.Name) ||
                String.IsNullOrEmpty(dto.Password))
                return NotFound(new { message = "Usuário ou senha inválidos" });

            var user = dto.ToUser();

            var result = new LoginResponseDTO(_userService.Authenticate(user));

            return result;
        }
    }
}