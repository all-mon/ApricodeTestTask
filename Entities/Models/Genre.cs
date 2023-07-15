using System.ComponentModel.DataAnnotations;

namespace Entities.Models
{
    public class Genre
    {
        public int Id { get; set; }
        [Required]
        [StringLength(100, MinimumLength = 3, ErrorMessage = "Название жанра должно быть от 3 до 100 символов")]
        public string? Name { get; set; }
        public ICollection<Game> Games { get; set; } = new List<Game>();
        public ICollection<GameGenre> GameGenres { get; set; } = new List<GameGenre>();
    }
}
