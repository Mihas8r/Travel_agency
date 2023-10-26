using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Hosting;
using System.Reflection.Metadata;

namespace Travel_agency.Models
{
    public class Destination
    {
        public int DestinationId { get; set; }
        public string? Location { get; set; }
        public int DepartDate { get; set; }
        public int  ReturnDate { get; set; }

        public int ClientId { get; set; }
        public Client? Client { get; set; }
    }   
}
