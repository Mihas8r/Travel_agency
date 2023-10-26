using AspNetCoreServicesApp.Repositories;
using Travel_agency.Models;
using Travel_agency.Repositories.Interfaces;

namespace Travel_agency.Repositories
{
    public class TravelGuideRepository : RepositoryBase<TravelGuide>, ITravelGuideRepository
    {
        public TravelGuideRepository(AgencyContext agencyContext)
          : base(agencyContext)
        {
        }
    }
}
