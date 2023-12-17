using HessalWebapp.Models;
using HessalWebapp.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace HessalWebapp.Controllers
{
    public class IndexModel : BasePageModel
    {
        private readonly ILogger<IndexModel> _logger;
        public BlogPostService _blogPostService;
        public IEnumerable<BlogPost> BlogPosts { get; private set; }
        public IndexModel(
            ILogger<IndexModel> logger,
            BlogPostService blogPostService)
        {
            _logger = logger;
            _blogPostService = blogPostService;
        }
        public void OnGet()
        {
            Theme = "light"; // Set the theme to light for this index page
            base.GetTheme(Theme);

            BlogPosts = _blogPostService.GetBlogPosts();
        }
    }
}