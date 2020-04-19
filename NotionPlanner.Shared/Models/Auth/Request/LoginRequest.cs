using System.ComponentModel.DataAnnotations;

namespace NotionPlanner.Shared.Models.Auth
{
    public class LoginRequest
    {
        [Required]
        [StringLength(50)]
        [EmailAddress]
        public string Email { get; set; }
        [Required]
        [StringLength(50)]
        public string Password { get; set; }
    }
}