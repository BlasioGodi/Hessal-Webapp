// Pages/Blog/BlogList.cshtml.cs
using HessalWebapp.Models;
using HessalWebapp.Services;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace HessalWebapp.Controllers {
    public class BlogListModel : BasePageModel
    {
        public BlogPostService _blogPostService;

        //Constructor to Initialize the BlogPostService
        public BlogListModel(BlogPostService blogPostService)
        {
            _blogPostService = blogPostService;
        }
        public void OnGet()
        {
            Theme = "dark"; // Set the theme to light for this blog list page
            base.GetTheme(Theme); 

            BlogPosts = _blogPostService.GetBlogPosts().Take(6);
        }
    }
}

