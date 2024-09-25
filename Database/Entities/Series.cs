using Database.Commons;

namespace Database.Entities
{
    public class Series : GenericEntity
    {
        public string VideoLink { get; set; }
        public int ProducerId { get; set; }
        public int PrimaryGenreId { get; set; }
        public int? SecondaryGenreId { get; set; }

        // Navigation properties
        public Producer Producer { get; set; }
        public Genre PrimaryGenre { get; set; }
        public Genre SecondaryGenre { get; set; }
    }
}
