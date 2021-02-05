using System.ComponentModel.DataAnnotations;

namespace Bintangku.Data.DTO
{
    public class RegisterDto
    {
        [Required]
        public string Username { get; set; }
        [Required]
        public string Password { get; set; }
    }
}