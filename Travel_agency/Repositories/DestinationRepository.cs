using AspNetCoreServicesApp.Repositories;
using Travel_agency.Models;
using Travel_agency.Repositories.Interfaces;

namespace Travel_agency.Repositories
{
    public class DestinationRepository : RepositoryBase<Destination>, IDestinationRepository
    {
        public DestinationRepository(AgencyContext agencyContext)
          : base(agencyContext)
        {
        }
    }
}
