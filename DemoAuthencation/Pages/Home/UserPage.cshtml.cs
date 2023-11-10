using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace DemoAuthencation.Pages.Home
{
    [Authorize]
    public class UserPageModel : PageModel
    {
        public void OnGet()
        {
        }
    }
}
