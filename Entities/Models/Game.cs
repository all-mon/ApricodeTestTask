using System.ComponentModel.DataAnnotations;

namespace Entities.Models
{
    public class Game
    {
        public int Id { get; set; }
        [Required]
        [StringLength(100, MinimumLength = 3, ErrorMessage = "Название игры должно быть от 3 до 100 символов")]
        public string? Name { get; set; }
        [Required]
        [StringLength(100, MinimumLength = 3, ErrorMessage = "Название студии должно быть от 3 до 100 символов")]
        public string? Studio { get; set; }
        public ICollection<Genre> Genres { get; set; } = new List<Genre>();
        public ICollection<GameGenre> GameGenres { get; set; } = new List<GameGenre>();
    }
}
