using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Hosting;
using System.Reflection.Metadata;

namespace Travel_agency.Models
{
    public class AgencyContext : IdentityDbContext<IdentityUser>
    {
        public AgencyContext(DbContextOptions<AgencyContext> options)
            : base(options)
        { }

        public DbSet<Client>? Clients { get; set; }
        public DbSet<Destination>? Destinations { get; set; }
        public DbSet<Hotel>? Hotels { get; set; }
        public DbSet<TourPackage>? TourPackages  { get; set; }
        public DbSet<TicketBooking>? Tickets { get; set; }
        public DbSet<TravelGuide>? TravelGuides { get; set; }

    }
}
