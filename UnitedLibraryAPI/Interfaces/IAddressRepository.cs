using UnitedLibraryAPI.Models;

namespace UnitedLibraryAPI.Interfaces
{
    public interface IAddressRepository
    {
        ICollection<Address> GetAddresses();

        ICollection<Address> GetAddressesByCity(string city);

        ICollection<Address> GetAddressesByState(string state);
    }
}
