using Microsoft.AspNetCore.Mvc.RazorPages;

namespace HessalWebapp.Models
{
    public class BasePageModel:PageModel
    {
        public List<BlogPost> BlogPosts { get; set; }
        public List<string> ServiceName { get; set; }
        public List<string> ProjectTitle { get; set; }
        public List<string> SocialIcons { get; set; }
        public string Theme { get; set; } = "light"; // Default to light
        public void GetTheme(string Theme)
        {
            if (Theme == "light")
            {
                ConfigureLightTheme();
            }
            else
            {
                ConfigureDarkTheme();
            }
        }
        private void ConfigureLightTheme()
        {
            //Footer Theme Definitions - Light Theme
            ViewData["Footer-bg"] = "bg-light";
            ViewData["Footer-text"] = "text-black";
            ViewData["Footer-Icon-List"] = "footer .no-icon-list:last-child a{ color: black;}";
            ViewData["Social-List-Light"] = ".social-list .bi , .social-list .fa{color: #606060;}";
            ViewData["Border"] = "border-custom-black";
            ViewData["CloseButton"] = "btn-close-dark";
        }
        private void ConfigureDarkTheme()
        {
            //Footer Theme Definitions - Dark Theme
            ViewData["Footer-bg"] = "bg-dark-custom";
            ViewData["Footer-text"] = "text-white";
            ViewData["Footer-Icon-List"] = "footer .no-icon-list:last-child a{ color: white;}";
            ViewData["Social-List-Light"] = ".social-list .bi , .social-list .fa{color: #f8f9fa;}";
            ViewData["Border"] = "border-custom-white";
            ViewData["CloseButton"] = "btn-close-white";
        }
    }
}
