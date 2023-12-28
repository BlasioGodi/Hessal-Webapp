using HessalWebapp.Models;
using System.ComponentModel.DataAnnotations;

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
