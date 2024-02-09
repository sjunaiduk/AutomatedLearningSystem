using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace AutomatedLearningSystem.Api.Pages
{
    public class IndexModel : PageModel
    {
        public IActionResult OnGet()
        {
            var path = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/client/index.html");
            return PhysicalFile(path, "text/html");
        }
    }
}
