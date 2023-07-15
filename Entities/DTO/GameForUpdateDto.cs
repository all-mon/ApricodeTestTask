using Entities.Validations;
using System.ComponentModel.DataAnnotations;

namespace Entities.DTO
{
    public class GameForUpdateDto
    {
        [Required]
        [StringLength(100, MinimumLength = 3, ErrorMessage = "Название игры должно быть от 3 до 100 символов")]
        public string? Name { get; set; }
        [Required]
        [StringLength(100, MinimumLength = 3, ErrorMessage = "Название студии должно быть от 3 до 100 символов")]
        public string? Studio { get; set; }
        [GenresIdsNotEmpty]
        public ICollection<int> GenresIds { get; set; } = new List<int>();
    }
}
