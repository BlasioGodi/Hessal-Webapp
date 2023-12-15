using HessalWebapp.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace HessalWebapp.Controllers
{
    public class ProjectsModel : BasePageModel
    {
        public new void OnGet()
        {
            Theme = "light"; // Set the theme to light for this projects page
            base.GetTheme(Theme);
        }
    }
}
