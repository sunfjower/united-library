using System.Text.Json.Serialization;

namespace UnitedLibraryAPI.Models
{
    public class NovelWriter
    {
        [JsonIgnore]
        public int NovelId { get; set; }

        [JsonIgnore]
        public Novel Novel { get; set; }

        [JsonIgnore]
        public int WriterId { get; set; }

        public Writer Writer { get; set; }
    }
}
