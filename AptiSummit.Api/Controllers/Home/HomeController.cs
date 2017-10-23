using Microsoft.AspNetCore.Mvc;

namespace AptiSummit.Api.Controllers.Home
{
    [Route("")]
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            var model = new HomeViewModel()
                .AddLink("/api/values", "values", "The values of the system");

            return Ok(model);
        }
    }
}