using Microsoft.EntityFrameworkCore;
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

        public async Task<ICollection<Address>> GetAllAddresses()
        {
            List<Address> addresses = await _context.Address
                .OrderBy(a => a.State)
                .ToListAsync();

            return addresses;
        }

        public async Task<ICollection<Address>> GetAddressesByCity(string city)
        {
            List<Address> addresses = await _context.Address
                .Where(a => a.City == city)
                .ToListAsync();

            return addresses;
        }

        public async Task<ICollection<Address>> GetAddressesByState(string state)
        {
            List<Address> addresses = await _context.Address
                .Where(a => a.State == state)
                .ToListAsync();

            return addresses;
        }

        public async Task<ICollection<Address>> GetAddressesByStateAndCity(string state, string city)
        {
            List<Address> addresses = await _context.Address
                .Where(a => a.State == state && a.City == city)
                .ToListAsync();

            return addresses;
        }
    }
}
