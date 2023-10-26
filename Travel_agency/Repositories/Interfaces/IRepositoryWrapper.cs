using Travel_agency.Services.Interfaces;

namespace Travel_agency.Repositories.Interfaces
{
    public interface IRepositoryWrapper
    {
        IClientRepository ClientRepository { get; }
        IDestinationRepository DestinationRepository { get; }
        IHotelRepository HotelRepository { get; }
        ITravelGuideRepository TravelGuideRepository { get; }


        void Save();
    }
}
