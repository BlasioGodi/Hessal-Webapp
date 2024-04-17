using HessalWebapp.Models;
using HessalWebapp.Services;
using Microsoft.AspNetCore.Mvc;

namespace HessalWebapp.Controllers
{
    public class LoadMoreController : Controller
    {
        public BlogPostService _blogPostService;
        public IEnumerable<BlogPost> BlogPosts { get; set; }
        public int Count { get; set; }
        public LoadMoreController(BlogPostService blogPostService)
        {
            _blogPostService = blogPostService;
        }

        public IActionResult Index()
        {
            return View();
        }
        [HttpGet("/LoadMore/GetBlogs")]
        public JsonResult GetBlogs(int skip, int take)
        {
            BlogPosts = _blogPostService.GetBlogPosts().Skip(skip).Take(take);

            return Json(BlogPosts);
        }
        [HttpGet("/LoadMore/GetCount")]
        public int GetCount()
        {
            Count = _blogPostService.GetBlogPosts().Count();
            return Count;
        }
    }
}
