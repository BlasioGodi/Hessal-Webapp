using Microsoft.AspNetCore.Mvc.RazorPages;

namespace HessalWebapp.Models
{
    public class BaseBlogPageModel:PageModel
    {
        public string Title { get; set; }
        public string Content { get; set; }
    }
}
