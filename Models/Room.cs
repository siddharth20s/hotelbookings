using System.ComponentModel.DataAnnotations;

namespace pracapiapp.Models
{
    public class Room
    {
        [Key]
        public int? RoomId { get; set; }

        [Required]
        public string? RoomNumber { get; set; }

        public string? Type { get; set; }

        [Range(1, 10)]
        public int? Capacity { get; set; }
        public int HotelId { get; set; }


        public Hotel? Hotel { get; set; }





    }
}
