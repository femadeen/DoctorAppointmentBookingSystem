using DoctorApoointmentBooking.DoctorAppointmentContext;
using DoctorApoointmentBooking.Entites;
using DoctorApoointmentBooking.Interfaces.Repositories;

namespace DoctorApoointmentBooking.Implementatios.Repositories
{
    public class PackingRepository : IPackingRepository
    {
        private readonly DoctorAppointmentDbContext _context;
        public PackingRepository(DoctorAppointmentDbContext context)
        {
            _context = context;
        }
        public Packing CreatePackingSpace(Packing packing)
        {
            _context.Packings.Add(packing);
            _context.SaveChanges();
            return packing;
        }

        public List<Packing> GetAllPAcking()
        {
            var parkingSpaces = _context.Packings.ToList();
            return parkingSpaces;
        }

        public List<Packing> GetAvailablePAckingSpace()
        {
            var availablePacking = _context.Packings.Where(p => p.IsAssigned == false).ToList();
            return availablePacking;
        }

        public Packing GetPackingSpace(int packingId)
        {
            var packingSpace = _context.Packings.SingleOrDefault(P => P.Id == packingId);
            return packingSpace;
        }

        public void RemovePacking(Packing packing)
        {
            _context.Remove(packing);
            _context.SaveChanges();
        }

        public Packing UpdatePacking(Packing packing)
        {
            _context.Update(packing);
            _context.SaveChanges();
            return packing;
        }
    }
}
