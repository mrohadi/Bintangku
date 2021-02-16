using System;

namespace Bintangku.Data.DTO
{
    public class MemberNakesUserUpdateDto
    {
        public string FullName { get; set; }
        public string Gender { get; set; }
        public int Age { get; set; }
        public long NoStrTenagaKesehatan { get; set; }
        public string TempatPelayanan { get; set; }
        public string PhoneNumber { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime LastActive { get; set; }
        public string PhotoUrl { get; set; }

    }
}