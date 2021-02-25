using System;
using System.Collections.Generic;

namespace Bintangku.Data.Entities
{
    public class NakesUser
    {
        public int Id { get; set; }
        public string UserName { get; set; }
        public string FullName { get; set; }
        public string Gender { get; set; }
        public DateTime DateOfBirth { get; set; }
        public long NoStrTenagaKesehatan { get; set; }
        public string TempatPelayanan { get; set; }
        public string PhoneNumber { get; set; }
        public DateTime CreatedAt { get; set; } = DateTime.Now;
        public DateTime LastActive { get; set; } = DateTime.Now;
        public byte[] PasswordHash { get; set; }
        public byte[] PasswordSalt { get; set; }

        public ICollection<Photo> Photos { get; set; }
        public ICollection<DataAnak> DataAnaks { get; set; }
    }
}