namespace Travel_agency.Models
{
    public class TravelGuide
    {
        public int TravelGuideId { get; set; }
        public string? TravelGuideName { get; set; }
        public string? TravelGuideDomain { get; set; }

        public int ClientId { get; set; }
        public Client? Client { get; set; }
    }
}
