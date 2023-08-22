using Microsoft.EntityFrameworkCore;
using UnitedLibraryAPI.Data;
using UnitedLibraryAPI.Dto;
using UnitedLibraryAPI.Interfaces;
using UnitedLibraryAPI.Models;

namespace UnitedLibraryAPI.Repository
{
    public class NovelRepository : INovelRepository
    {
        private readonly UnitedLibraryContext _context;

        public NovelRepository(UnitedLibraryContext context) 
        {
            _context = context;   
        }

        public async Task<ICollection<Novel>> GetAllNovels()
        {
            List<Novel> novels = await _context.Novels.OrderBy(n => n.Name).ToListAsync();
            return novels;
        }
    }
}
