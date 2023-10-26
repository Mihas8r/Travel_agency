using Microsoft.Extensions.Hosting;

namespace Travel_agency.Models
{
    public class Client
    {
        public int ClientId { get; set; }
        public string? ClientName { get; set; }
        public string? ClientAddress { get; set; }

        public ICollection<Destination>? Destinations { get; set; }

        public ICollection<TravelGuide>? TravelGuides { get; set; }

        public ICollection<Hotel>? Hotel { get; set; }


    }
}
