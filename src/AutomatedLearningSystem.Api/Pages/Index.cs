using Microsoft.AspNetCore.Mvc;

namespace AutomatedLearningSystem.Api.Pages
{
    public class ReactApp : Controller
    {
        [Route("/")]
        public IActionResult Index()
        {
            var path = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/client/index.html");
            return PhysicalFile(path, "text/html");
        }
    }
}
