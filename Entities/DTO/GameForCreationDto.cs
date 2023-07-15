namespace Entities.DTO
{
    public class GameForCreationDto
    {
        public string? Name { get; set; }
        public string? Studio { get; set; }
        public ICollection<int> GenresIds { get; set; } = new List<int>();
    }
}
