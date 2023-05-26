using System.ComponentModel.DataAnnotations;

namespace pracapiapp.Models
{
    public class Employee
    {
        [Key]
        public int? EmployeeId { get; set; }

        [Required]
        public string? FirstName { get; set; }

        [Required]
        public string? LastName { get; set; }

        public string? Email { get; set; }
        public int HotelId { get; set; }

        public Hotel? Hotel { get; set; }


    }
}
