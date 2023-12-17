using HessalWebapp.Models;
using HessalWebapp.Services;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Reflection;

namespace HessalWebapp.Controllers
{
    public class HeaderModel:BasePageModel
    {
        private readonly BlogPostService _blogPostService;

        public HeaderModel(BlogPostService blogPostService) 
        {
            _blogPostService =  blogPostService;
        }
        public IEnumerable<BlogPost> BlogPosts { get; set; }
        public void OnGet()
        {
            BlogPosts = _blogPostService.GetBlogPosts();
        }
    }
}
