using HessalWebapp.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace HessalWebapp.Controllers
{
    public class TermsModel : BasePageModel
    {
        public void OnGet()
        {
            Theme = "light"; // Set the theme to light for this terms page
            base.GetTheme(Theme);
        }
    }
}
