using UnitedLibraryAPI.Models;

namespace UnitedLibraryAPI.Interfaces
{
    public interface IBookRepository
    {
        Task<ICollection<Book>> GetAllBooks();

        Task<ICollection<Book>> GetBooksByLocationAndNovel(string city, string state,string novel);
    }
}
