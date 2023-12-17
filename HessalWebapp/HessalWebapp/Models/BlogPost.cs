using System.Text.Json;
using System.Text.Json.Serialization;

namespace HessalWebapp.Models
{
    public class BlogPost
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Author { get; set; }
        public string Content { get; set; }
        public DateTime PublishedDate { get; set; } = DateTime.Now; // Default to current date

        [JsonPropertyName("img")]
        public string ImageUrl { get; set; }
        public override string ToString() => JsonSerializer.Serialize<BlogPost>(this);
    }
}
