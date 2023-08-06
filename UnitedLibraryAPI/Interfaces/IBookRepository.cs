using UnitedLibraryAPI.Models;

namespace UnitedLibraryAPI.Interfaces
{
    public interface IBookRepository
    {
        ICollection<Book> GetAllBooks();

        ICollection<Book> GetBooksByLibraryAndNovel(string city, string state,string novel);
    }
}
