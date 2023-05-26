namespace pracapiapp.DTO
{
    public class AvailableRoomsDTO
    {
        public int HotelId { get; set; }
        public string? HotelName { get; set; }
        public string? Address { get; set; }
        public string? City { get; set; }
        public int Ratings { get; set; }
        public string? Phone { get; set; }
        public List<RoomDto>? AvailableRooms { get; set; }
    }

    public class RoomDto
    {
        public int RoomId { get; set; }
        public string? RoomNumber { get; set; }
        public string? Type { get; set; }
        public string? Availability { get; set; }
        public decimal Price { get; set; }
    }
}