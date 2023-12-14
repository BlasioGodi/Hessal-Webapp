using HessalWebapp.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace HessalWebapp.Pages.Blog
{
    public class BlogPostModel:BaseBlogPageModel
    {
        public void OnGet()
        {
            Title = "LPG Production";
            Content = "Production of LPG Gas involves Fractional distillation";
        }
    }
}
