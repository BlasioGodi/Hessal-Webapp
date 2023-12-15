using Microsoft.AspNetCore.Mvc.RazorPages;

namespace HessalWebapp.Models
{
    public class BlogPost:PageModel
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Content { get; set; }
        public DateTime Date { get; set; }
    }
}
