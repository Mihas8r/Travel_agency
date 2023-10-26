using Travel_agency.Models;
using Travel_agency.Repositories;
using Travel_agency.Repositories.Interfaces;


namespace AspNetCoreServicesApp.Repositories
{
    public class RepositoryWrapper : IRepositoryWrapper
    {
        private AgencyContext _agencyContext;
        private IClientRepository? _clientRepository;
        private IDestinationRepository? _destinationRepository;
        private ITravelGuideRepository? _guideRepository;
        private IHotelRepository? _hotelRepository;



        public IClientRepository ClientRepository
        {
            get
            {
                if (_clientRepository == null)
                {
                    _clientRepository = new ClientRepository(_agencyContext);
                }

                return _clientRepository;
            }
        }

        public IDestinationRepository DestinationRepository
        {
            get
            {
                if (_destinationRepository == null)
                {
                    _destinationRepository = new DestinationRepository(_agencyContext);
                }

                return _destinationRepository;
            }
        }

        public ITravelGuideRepository TravelGuideRepository
        {
            get
            {
                if (_guideRepository == null)
                {
                    _guideRepository = new TravelGuideRepository(_agencyContext);
                }

                return _guideRepository;
            }
        }

        public IHotelRepository HotelRepository
        {
            get
            {
                if (_hotelRepository == null)
                {
                    _hotelRepository = new HotelRepository(_agencyContext);
                }

                return _hotelRepository;
            }
        }

       
        public RepositoryWrapper(AgencyContext agencyContext)
        {
            _agencyContext = agencyContext;
        }

        public void Save()
        {
            _agencyContext.SaveChanges();
        }
    }
}
