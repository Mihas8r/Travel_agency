using AspNetCoreServicesApp.Repositories;
using Microsoft.CodeAnalysis;
using Travel_agency.Models;
using Travel_agency.Repositories.Interfaces;

namespace Travel_agency.Repositories
{
    public class ClientRepository : RepositoryBase<Client>, IClientRepository
    {
        public ClientRepository(AgencyContext agencyContext)
           : base(agencyContext)
        {
        }
    }
}
