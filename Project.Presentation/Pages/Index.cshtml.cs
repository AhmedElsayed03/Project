using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Project.Presentation.Pages
{
    public class IndexModel : PageModel
    {
        private readonly ILogger<IndexModel> _logger;
        public IndexModel(ILogger<IndexModel> logger)
        {
            _logger = logger;
        }
        [BindProperty (SupportsGet = true)] //Support get used to recieve params from URL as a query string
        public string? FirstName { get; set; }
        public void OnGet()
        {

        }
    }
}
