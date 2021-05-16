using System.ComponentModel.DataAnnotations;

namespace Bintangku.WebApi.Data.DTO
{
    public class LoginDto
    {
        // [Required]
        public string Username { get; set; }
        // [Required]
        public string Password { get; set; }
    }
}