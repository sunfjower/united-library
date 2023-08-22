using UnitedLibraryAPI.Models;

namespace UnitedLibraryAPI.Interfaces
{
    public interface IAddressRepository
    {
        Task<ICollection<Address>> GetAllAddresses();

        Task<ICollection<Address>> GetAddressesByCity(string city);

        Task<ICollection<Address>> GetAddressesByState(string state);

        Task<ICollection<Address>> GetAddressesByStateAndCity(string state, string city);

    }
}
