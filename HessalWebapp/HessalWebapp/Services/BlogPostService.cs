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
            var blogPosts = GetBlogPosts();
            return blogPosts.FirstOrDefault(post => post.Id == postId);
        }
    }
}
