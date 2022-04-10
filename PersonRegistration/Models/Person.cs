

using System.ComponentModel.DataAnnotations;

namespace PersonRegistration.Models
{
    public class Person
    {
        public int Id { get; set; }
        [MinLength(2)]
        [MaxLength(50)]

        public string FirstName { get; set; }

        [MinLength(2)]
        [MaxLength(50)]
        public string LastName { get; set; }
        public Gender Gender { get; set; }
        [MinLength(11)]
        [MaxLength(11)]
        public string PN { get; set; }
        public DateTime BirthDate { get; set; } 
        public int CityId { get; set; }

        [MinLength(4)]
        [MaxLength(50)]
        public string PhoneNumber { get; set; }
        public string PhotoPath { get; set; }

    }
}
