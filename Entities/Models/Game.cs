namespace Entities.Models
{
    public class Game
    {
        public int GameId { get; set; }
        public string? Name { get; set; }
        public string? Studio { get; set; }
        public ICollection<Genre> Genres { get; set; } = new List<Genre>();
    }
}
