using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Query.Internal;
using UnitedLibraryAPI.Interfaces;
using UnitedLibraryAPI.Data;
using UnitedLibraryAPI.Models;
using Microsoft.AspNetCore.Authentication.Cookies;

namespace UnitedLibraryAPI.Repository
{
    public class BookRepository : IBookRepository
    {
        private readonly UnitedLibraryContext _context;

        public BookRepository(UnitedLibraryContext context) 
        {
            _context = context;
        }

        public ICollection<Book> GetBooks() 
        {
            List<Book> books = _context.Books.OrderBy(b => b.Title).ToList();
            return books;
        }

        public ICollection<Book> GetBooks(string title)
        {
            List<Book> books = _context.Books.Where(b => (b.Title).Contains(title)).ToList();
            return books;
        }
    }
}
