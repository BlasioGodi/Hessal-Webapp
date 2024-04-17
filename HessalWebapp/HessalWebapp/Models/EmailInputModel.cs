using HessalWebapp.Controllers;
using System.ComponentModel.DataAnnotations;

namespace HessalWebapp.Models
{
    public class EmailInputModel
    {
        [Required]
        public string FirstName { get; set; }

        [Required]
        public string LastName { get; set; }

        [Required]
        [EmailAddress]
        public string Email { get; set; }

        [Required]
        public string Contact { get; set; }

        [Required]
        public string Message { get; set; }
    }
}
