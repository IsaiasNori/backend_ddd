using System;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Api.Controllers
{
    [ApiController]
    [Route("api/v1/[controller]")]
    public class StatusController : BaseApiController
    {

        public StatusController() : base()
        {
        }

        [AllowAnonymous]
        [HttpGet]
        public ActionResult<String> Get()
        {
            String date = "System Date: " + DateTimeOffset.UtcNow.ToString();

            String env = "Environment: " + Environment.GetEnvironmentVariable("ASPNETCORE_ENVIRONMENT");

            var result = $"{env}\n{date}\nOk";

            return Ok(result);
        }
    }
}
