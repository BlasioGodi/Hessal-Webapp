using HessalWebapp.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace HessalWebapp.Controllers
{
    public class ContactModel : BasePageModel
    {
        public void OnGet()
        {
            Theme = "light"; // Set the theme to light for this contact page
            base.GetTheme(Theme);
        }
    }
}