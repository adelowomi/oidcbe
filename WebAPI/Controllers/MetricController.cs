using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace WebAPI.Controllers
{
    [Authorize]
    public class MetricController : Controller
    {
        
        public MetricController ()
        {

        }

        [HttpGet]
        [Route("api/metrics/log")]
        public IActionResult Index()
        {
            return View();
        }
    }
}
