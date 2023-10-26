namespace Travel_agency.Models
{
    public class Hotel
    {
        public int HotelId { get; set; }
        public string? HotelName { get; set; }
        public string? HotelAddress { get; set; }
        public string? Description{ get; set; }

        public int ClientId { get; set; }
        public Client? Client { get; set; }

    }
}
