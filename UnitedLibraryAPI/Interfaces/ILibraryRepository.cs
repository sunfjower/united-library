using UnitedLibraryAPI.Models;

namespace UnitedLibraryAPI.Interfaces
{
    public interface ILibraryRepository
    {
        Task<ICollection<Library>> GetAllLibraries();

        Task<ICollection<Library>> GetLibrariesByLocationAndBookId(string state, string city, int bookId);

        Task<ICollection<Library>> GetLibrariesByStateAndCity(string state, string city);
    }
}
