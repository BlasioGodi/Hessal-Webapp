using HessalWebapp.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace HessalWebapp.Controllers
{
    public class AboutModel : BasePageModel
    {
        public void OnGet()
        {
            Theme = "dark"; // Set the theme to light for this about page
            base.GetTheme(Theme);
        }
    }
}
