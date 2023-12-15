using HessalWebapp.Models;
using HessalWebapp.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace HessalWebapp.Controllers
{
    public class BlogPostModel : BasePageModel
    {
        private readonly BlogPostService _blogPostService;
        public BlogPostModel(BlogPostService blogPostService)
        {
            _blogPostService = blogPostService;
        }
        public BlogPost BlogPost { get; private set; }

        public IActionResult OnGet(int id) // Assuming the ID is used to identify the blog post
        {
            Theme = "dark"; // Set the theme to light for this blog post page
            base.GetTheme(Theme);

            BlogPost = _blogPostService.GetBlogPostById(id);
            if (BlogPost == null)
            {
                return NotFound(); // Or handle the case where the blog post is not found
            }
            return Page();
        }
    }
}



