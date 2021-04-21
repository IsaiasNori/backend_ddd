using System.Text.Json;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Api.Controllers
{
    [Route("api/v1/[controller]")]
    public class HomeController : BaseApiController
    {
        public HomeController() : base()
        {
        }

        [HttpGet]
        [Authorize(Roles = "admin")]
        public ActionResult<dynamic> Get()
        {
            var a = User;

            var options = new JsonSerializerOptions()
            {
                IgnoreReadOnlyProperties = true,
                WriteIndented = true
            };

            var result = JsonSerializer.Serialize(a, options);

            return result;
        }
    }
}