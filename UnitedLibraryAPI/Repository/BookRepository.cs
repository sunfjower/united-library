using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Query.Internal;
using UnitedLibraryAPI.Interfaces;
using UnitedLibraryAPI.Data;
using UnitedLibraryAPI.Models;
using Microsoft.AspNetCore.Authentication.Cookies;
using AutoMapper;

namespace UnitedLibraryAPI.Repository
{
    public class BookRepository : IBookRepository
    {
        private readonly UnitedLibraryContext _context;

        public BookRepository(UnitedLibraryContext context)
        {
            _context = context;
        }

        public ICollection<Book> GetAllBooks()
        {
            List<Book> books = _context.Books.OrderBy(b => b.Title).ToList();
            return books;
        }

        public ICollection<Book> GetBooksByLibraryAndNovel(string city = "Kryvyi Rih", string state = "Dnipropetrovsk Oblast", string novel = "1984")
        {
            List<Book> books = _context.Books
                .FromSql($"SELECT [b].[Id], [b].[FrontCoverPath], [b].[Title]\r\nFROM [Books] AS [b]\r\nLEFT JOIN (\r\n    SELECT [b0].[BookId], [b0].[NovelId], [n].[Id], [n].[Name]\r\n    FROM [BookNovels] AS [b0]\r\n    INNER JOIN [Novels] AS [n] ON [b0].[NovelId] = [n].[Id]\r\n) AS [t] ON [b].[Id] = [t].[BookId]\r\nLEFT JOIN (\r\n    SELECT [l].[LibraryId], [l].[BookId], [l].[InAvailable], [l0].[Id], [l0].[Name], [a].[City], [a].[State]\r\n    FROM [LibraryBooks] AS [l]\r\n    INNER JOIN [Libraries] AS [l0] ON [l].[LibraryId] = [l0].[Id]\r\n    LEFT JOIN [Address] AS [a] ON [l0].[Id] = [a].[LibraryId]\r\n) AS [t0] ON [b].[Id] = [t0].[BookId]\r\nWHERE [t].[Name] = '1984' AND [t0].[State] = 'Dnipropetrovsk Oblast' AND [t0].[City] = 'Kryvyi Rih'")
                .Include(b => b.Novels)
                    .ThenInclude(n => n.Novel)
                    .ThenInclude(n => n.Writers)
                    .ThenInclude(w => w.Writer)
                .ToList();

            return books;
        }
    }
}
