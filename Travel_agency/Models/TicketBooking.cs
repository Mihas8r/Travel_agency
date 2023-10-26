namespace Travel_agency.Models
{
    public class TicketBooking
    {
        public int TicketBookingId { get; set; }
        public int TicketDate { get; set; }
        public int SeatNumber { get; set; }

        public int DestinationId { get; set; }

        public Destination? Destination { get; set; }

    }
}
