// Pages/Blog/BlogList.cshtml.cs
using HessalWebapp.Models;
using HessalWebapp.Services;
using Microsoft.AspNetCore.Mvc.RazorPages;

public class BlogListModel : PageModel
{
    private readonly BlogPostService _blogPostService;

    //Constructor to Initialize the BlogPostService
    public BlogListModel(BlogPostService blogPostService)
    {
        _blogPostService = blogPostService;
    }
    //Initialization of the BlogPost Model to retrieve data
    public List<BlogPost> BlogPosts { get; set; }

    public void OnGet()
    {
        BlogPosts = _blogPostService.GetBlogPosts();
    }
}
