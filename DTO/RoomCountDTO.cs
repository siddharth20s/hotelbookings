namespace pracapiapp.DTO
{
    public class RoomCountDTO
    {
        public int Id { get; set; }
        public string? Name { get; set; }
        public string? Address { get; set; }
        public string? City { get; set; }
        public int Ratings { get; set; }
        public string? Phone { get; set; }
        public int TotalAvailableRooms { get; set; }
    }
}