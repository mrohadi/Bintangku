using System.ComponentModel.DataAnnotations;

namespace Bintangku.Data.DTO
{
    public class RegisterDto
    {
        [Required]
        public string Email { get; set; }
        [Required]
        public string Username { get; set; }
        
        [Required]
        public string FullName { get; set; }

        public string PhoneNumber { get; set; }

        [Required]
        public long NoStrTenagaKesehatan { get; set; }

        [Required]
        public string TempatPelayanan { get; set; }

        [Required]
        [StringLength(8, MinimumLength = 4)]
        public string Password { get; set; }
    }
}