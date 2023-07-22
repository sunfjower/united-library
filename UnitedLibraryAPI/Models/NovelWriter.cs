namespace UnitedLibraryAPI.Models
{
    public class NovelWriter
    {
        public int NovelId { get; set; }
        public Novel Novel { get; set; }

        public int WriterId { get; set; }
        public Writer Writer { get; set; }
    }
}
