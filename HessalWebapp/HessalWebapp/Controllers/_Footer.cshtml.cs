using HessalWebapp.Models;
using HessalWebapp.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace HessalWebapp.Controllers
{
    public class FooterModel : BasePageModel
    {
        private readonly BlogPostService _blogPostService;

        public FooterModel(BlogPostService blogPostService)
        {
            _blogPostService = blogPostService;
        }
        public IEnumerable<BlogPost> BlogPosts { get; set; }
        public void OnGet()
        {
            BlogPosts = _blogPostService.GetBlogPosts();
        }
    }
}
