using HessalWebapp.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace HessalWebapp.Controllers
{
    public class ServicesModel : BasePageModel
    {
        public void OnGet()
        {
            Theme = "light"; // Set the theme to light for this services page
            base.GetTheme(Theme);
        }
    }
}
