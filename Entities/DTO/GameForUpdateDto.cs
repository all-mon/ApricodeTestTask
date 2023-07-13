namespace Entities.DTO
{
    public class GameForUpdateDto
    {
        public string? Name { get; set; }
        public string? Studio { get; set; }
        public ICollection<int> GenresIds { get; set; } = new List<int>();
    }
}
