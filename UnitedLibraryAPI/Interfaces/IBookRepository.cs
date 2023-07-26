using UnitedLibraryAPI.Models;

namespace UnitedLibraryAPI.Interfaces
{
    public interface IBookRepository
    {
        ICollection<Book> GetBooks();

        ICollection<Book> GetBooks(string title);
    }
}
