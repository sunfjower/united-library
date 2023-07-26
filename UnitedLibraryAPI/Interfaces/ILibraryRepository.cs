using UnitedLibraryAPI.Models;

namespace UnitedLibraryAPI.Interfaces
{
    public interface ILibraryRepository
    {
        ICollection<Library> GetLibraries();

        ICollection<Library> GetLibraries(string address);
    }
}
