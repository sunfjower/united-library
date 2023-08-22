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

        public async Task<ICollection<Book>> GetAllBooks()
        {
            List<Book> books = await _context.Books.OrderBy(b => b.Title).ToListAsync();
            return books;
        }

        public async Task<ICollection<Book>> GetBooksByLocationAndNovel(string state, string city, string novel)
        {
            List<Book> books = await _context.Books
                .Where(b => b.Libraries.Any(l => l.Library.PhysicalAddress.State == state && l.Library.PhysicalAddress.City == city) && b.Novels.Any(n => n.Novel.Name == novel))
                .Include(b => b.Novels)
                    .ThenInclude(n => n.Novel)
                .ToListAsync();

            /*List<Book> books = await _context.Books
                .FromSql($"SELECT [b].[Id], [b].[FrontCoverPath], [b].[Title]\r\nFROM [Books] AS [b]\r\nLEFT JOIN (\r\n    SELECT [b0].[BookId], [b0].[NovelId], [n].[Id], [n].[Name]\r\n    FROM [BookNovels] AS [b0]\r\n    INNER JOIN [Novels] AS [n] ON [b0].[NovelId] = [n].[Id]\r\n) AS [t] ON [b].[Id] = [t].[BookId]\r\nLEFT JOIN (\r\n    SELECT [l].[LibraryId], [l].[BookId], [l].[InAvailable], [l0].[Id], [l0].[Name], [a].[City], [a].[State]\r\n    FROM [LibraryBooks] AS [l]\r\n    INNER JOIN [Libraries] AS [l0] ON [l].[LibraryId] = [l0].[Id]\r\n    LEFT JOIN [Address] AS [a] ON [l0].[Id] = [a].[LibraryId]\r\n) AS [t0] ON [b].[Id] = [t0].[BookId]\r\nWHERE [t].[Name] = {novel} AND [t0].[State] = {state} AND [t0].[City] = {city}")
                .Include(b => b.Novels)
                    .ThenInclude(n => n.Novel)
                .ToListAsync();*/

            return books;
        }
    }
}
