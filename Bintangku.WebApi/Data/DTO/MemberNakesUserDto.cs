using System;
using System.Collections.Generic;
using Bintangku.Data.Entities;

namespace Bintangku.Data.DTO
{
    public class MemberNakesUserDto
    {
        public int Id { get; set; }
        public string Username { get; set; }
        public string FullName { get; set; }
        public string Gender { get; set; }
        public int Age { get; set; }
        public long NoStrTenagaKesehatan { get; set; }
        public string TempatPelayanan { get; set; }
        public string PhoneNumber { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime LastActive { get; set; }
        public string PhotoUrl { get; set; }

        public ICollection<PhotoDto> Photos { get; set; }

    }
}