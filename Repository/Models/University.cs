using DbContextAdoNet.Attributes;
using System;

namespace Repository.Models
{
    public class University
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; }
        public string PhoneNumber { get; set; }
        public string Email { get; set; }
        public int? AddressId { get; set; }
        [Date]
        public DateTime? DestroyDate { get; set; }

        [Ignore]
        public Address Address { get; set; }

        public override string ToString()
        {
            return $"{Id}\t{Name}\t{PhoneNumber}\t{Email}\t{AddressId}\t{DestroyDate}";
        }
    }
}
