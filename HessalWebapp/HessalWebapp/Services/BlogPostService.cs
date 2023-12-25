using System.Text.Json;
using HessalWebapp.Models;

namespace HessalWebapp.Services
{
    public class BlogPostService
    {
        public BlogPostService(IWebHostEnvironment webHostEnvironment) => WebHostEnvironment = webHostEnvironment;
        public IWebHostEnvironment WebHostEnvironment { get; }
        private string JsonFileName
        {
            get { return Path.Combine(WebHostEnvironment.WebRootPath, "data", "BlogList.json"); }
        }
        public IEnumerable<BlogPost> GetBlogPosts()
        {
            using (var jsonFileReader = File.OpenText(JsonFileName))
            {
                return JsonSerializer.Deserialize<BlogPost[]>(jsonFileReader.ReadToEnd(),
                    new JsonSerializerOptions
                    {
                        PropertyNameCaseInsensitive = true
                    });
            }
        }
        public BlogPost GetBlogPostById(int postId)
        {
            var blogPostId = GetBlogPosts();
            return blogPostId.FirstOrDefault(post => post.Id == postId);
        }

        public BlogPost GetBlogPostByTitle(string postTitle)
        {
            var blogPostTitle = GetBlogPosts();
            return blogPostTitle.FirstOrDefault(post => post.Title == postTitle);
        }

        public BlogPost GetBlogPostByPage(string postName)
        {
            var blogPostTitle = GetBlogPosts();
            return blogPostTitle.FirstOrDefault(post => post.PageName == postName);
        }
    }
}
