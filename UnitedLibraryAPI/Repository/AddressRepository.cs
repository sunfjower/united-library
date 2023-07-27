using UnitedLibraryAPI.Data;
using UnitedLibraryAPI.Interfaces;
using UnitedLibraryAPI.Models;

namespace UnitedLibraryAPI.Repository
{
    public class AddressRepository : IAddressRepository
    {
        private readonly UnitedLibraryContext _context; 

        public AddressRepository(UnitedLibraryContext context) 
        {
            _context = context;
        }

        public ICollection<Address> GetAddresses()
        {
            List<Address> addresses = _context.Address.OrderBy(a => a.State).ToList();
            return addresses;
        }

        public ICollection<Address> GetAddressesByCity(string city)
        {
            List<Address> addresses = _context.Address.Where(a => a.City == city).ToList();
            return addresses;
        }

        public ICollection<Address> GetAddressesByState(string state)
        {
            List<Address> addresses = _context.Address.Where(a => a.State == state).ToList();
            return addresses;
        }
    }
}
