using System.ComponentModel.DataAnnotations;

namespace pracapiapp.Models
{
    public class Hotel
    {
        [Key]
        public int HotelId { get; set; }

        [Required]
        public string? Name { get; set; }

        public string? Address { get; set; }

        [DataType(DataType.PhoneNumber)]
        public string? PhoneNumber { get; set; }

        public virtual ICollection<Room>? Rooms { get; set; }
        public virtual ICollection<Employee>? Employees { get; set; }
        public virtual ICollection<Customer>? Customers { get; set; }
    }
}
