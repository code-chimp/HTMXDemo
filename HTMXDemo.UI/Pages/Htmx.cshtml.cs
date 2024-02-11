using Htmx;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace HTMXDemo.UI.Pages;

public class Htmx : PageModel
{
    public IActionResult OnGet()
    {
        return Request.IsHtmx()
            ? Content("<span>Hello from the backend!</span>", "text/html")
            : Page();
    }
}