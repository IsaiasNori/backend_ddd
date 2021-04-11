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
            var result = User.Identity.Name;

            return result;
        }
    }
}