using AspNetCoreServicesApp.Repositories;
using Travel_agency.Models;
using Travel_agency.Repositories.Interfaces;

namespace Travel_agency.Repositories
{
    public class HotelRepository : RepositoryBase<Hotel>, IHotelRepository
    {
        public HotelRepository(AgencyContext agencyContext)
           : base(agencyContext)
        {
        }
    }
}
