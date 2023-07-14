namespace Entities.DTO
{
    public class GameDto
    {
        public int Id { get; set; }
        public string? Name { get; set; }
        public string? Studio { get; set; }

        public ICollection<GenreDto>? Genres { get; set; }
    }
}
