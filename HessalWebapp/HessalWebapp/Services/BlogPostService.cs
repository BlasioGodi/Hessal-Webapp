using System;
using System.Collections.Generic;
using System.Linq;
using HessalWebapp.Models;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace HessalWebapp.Services
{
    public class BlogPostService:PageModel
    {
        // Replace List<BlogPost> with your actual data source
        private readonly List<BlogPost> _blogPosts;

        //Constructor to Initialize Blog Post Service
        public BlogPostService()
        {
            // Initialize your blog posts data
            _blogPosts = new List<BlogPost>
            {
                new BlogPost { Id = 1, Title = "LPG", Content = "Lorem ipsum...", Date = DateTime.Now },
            new BlogPost { Id = 2, Title = "LPG Production", Content = "Dolor sit amet...", Date = DateTime.Now.AddDays(-1) },
            new BlogPost { Id = 3, Title = "Gas Leak Detection", Content = "Dolor sit amet...", Date = DateTime.Now.AddDays(-1) },
            new BlogPost { Id = 4, Title = "Fire Safety", Content = "Dolor sit amet...", Date = DateTime.Now.AddDays(-1) },
            new BlogPost { Id = 5, Title = "Gas Pipes", Content = "Dolor sit amet...", Date = DateTime.Now.AddDays(-1) },
            new BlogPost { Id = 6, Title = "Gas Accessories", Content = "Dolor sit amet...", Date = DateTime.Now.AddDays(-1) },
            new BlogPost { Id = 7, Title = "Non-destructive Testing", Content = "Dolor sit amet...", Date = DateTime.Now.AddDays(-1) },
            new BlogPost { Id = 8, Title = "Earthing", Content = "Dolor sit amet...", Date = DateTime.Now.AddDays(-1) },
            new BlogPost { Id = 9, Title = "Hello World Blog", Content = "Dolor sit amet...", Date = DateTime.Now.AddDays(-1) }
                // Add more blog posts as needed
            };
        }

        public List<BlogPost> GetBlogPosts()
        {
            // Logic to retrieve blog posts from a data source
            return _blogPosts;
        }
        public BlogPost GetBlogPostById(int id)
        {
            return _blogPosts.FirstOrDefault(post => post.Id == id);
        }
    }
}



