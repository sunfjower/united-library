using UnitedLibraryAPI.Models;

namespace UnitedLibraryAPI.Interfaces
{
    public interface IWriterRepository
    {
        Task<ICollection<Writer>> GetAllWriters();

        Task<ICollection<Writer>> GetWritersByBookId(int bookId);
    }
}
