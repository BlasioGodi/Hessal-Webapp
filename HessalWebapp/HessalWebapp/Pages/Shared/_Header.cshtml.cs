using System.Collections.Generic;
using HessalWebapp.Pages.Blog;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace HessalWebapp.Pages.Shared
{
    public class HeaderModel : PageModel
    {
        public List<string> ServiceName { get; set; }
        public List<string> ProjectTitle { get; set; }
        public List<string> BlogTitles { get; set; }
        public List <string> SocialIcons { get; set; }

        public void OnGet()
        {
        }
    }
}
