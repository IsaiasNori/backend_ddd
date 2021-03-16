using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Domain.Core.Services;
using System.Collections.Generic;
using Api.DTO;
using System.Linq;
using System;

namespace Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class UserController : BaseController
    {
        private readonly IUserService _service;
        public UserController(IUserService service) : base()
        {
            _service = service;
        }

        [AllowAnonymous]
        [HttpGet]
        public ActionResult<List<UserDTO>> GetAll()
        {
            var user = _service.Get();

            var result = user.Select(e => new UserDTO(e)).ToList();

            return result;

        }

        [AllowAnonymous]
        [HttpGet("{id}")]
        public ActionResult<UserDTO> Get([FromRoute] String id)
        {
            var result = new UserDTO(_service.Get(id));

            return result;

        }

        [AllowAnonymous]
        [HttpPost]
        public ActionResult<UserDTO> Post([FromBody] UserDTO dto)
        {
            var user = dto.ToModel();

            // var result = _service.Create(user);
            user.Id = "aaaaahhhhhnnnnn";

            return new UserDTO(user);

        }
    }
}
