using UnitedLibraryAPI.Data;
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

        public Novel GetNovelByName(string name)
        {
            Novel novel = _context.Novels.Where(n => n.Name == name).FirstOrDefault();
            return novel;
        }

        public ICollection<Novel> GetNovels()
        {
            List<Novel> novels = _context.Novels.OrderBy(n => n.Name).ToList();
            return novels;
        }

        public ICollection<Novel> GetNovelsByName(string name)
        {
            List<Novel> novels = _context.Novels.Where(n => n.Name.Contains(name)).ToList();
            return novels;
        }
    }
}
