using UnitedLibraryAPI.Models;

namespace UnitedLibraryAPI.Interfaces
{
    public interface INovelRepository
    {
        ICollection<Novel> GetNovels();

        ICollection<Novel> GetNovelsByName(string name);

        Novel GetNovelByName(string name);
    }
}
