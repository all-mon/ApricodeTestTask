namespace Entities.DTO
{
    public class GameDto
    {
        public int GameId { get; set; }
        public string? Name { get; set; }
        public string? Studio { get; set; }

        public ICollection<GenreDto>? Genres { get; set; }
    }
}
