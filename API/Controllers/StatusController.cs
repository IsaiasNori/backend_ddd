using System;
using System.Collections;
using System.Globalization;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Mvc;

namespace Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class StatusController : BaseController
    {

        public StatusController() : base()
        {
        }

        [AllowAnonymous]
        [HttpGet]
        public ActionResult<String> Get()
        {
            //String now = DateTimeOffset.UtcNow.ToString("u", new CultureInfo("pt-BR"));

            String result = "Date System: " + DateTimeOffset.UtcNow.ToString("yyyy-MM-dd HH:mm:ss");

            result += "\nEnvironment: Development";

            return Ok(result);
        }
    }
}
