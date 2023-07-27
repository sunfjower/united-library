using UnitedLibraryAPI.Models;

namespace UnitedLibraryAPI.Interfaces
{
    public interface IWriterRepository
    {
        ICollection<Writer> GetWriters();
    }
}
