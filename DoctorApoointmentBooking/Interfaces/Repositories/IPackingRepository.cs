using DoctorApoointmentBooking.Entites;

namespace DoctorApoointmentBooking.Interfaces.Repositories
{
    public interface IPackingRepository
    {
        Packing CreatePackingSpace(Packing packing);
        Packing UpdatePacking(Packing packing);
        void RemovePacking (Packing packing);
        Packing GetPackingSpace (int packingId);
        List<Packing> GetAllPAcking();
        List<Packing> GetAvailablePAckingSpace();

    }
}
