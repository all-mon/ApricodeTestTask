using Entities.Validations;
using System.ComponentModel.DataAnnotations;

namespace Entities.DTO
{
    public class GameForCreationDto
    {
        [Required]
        [StringLength(100, MinimumLength = 3, ErrorMessage = "Название должно быть от 3 до 100 символов")]
        public string? Name { get; set; }
        public string? Studio { get; set; }
        [GenresIdsNotEmpty]
        public ICollection<int> GenresIds { get; set; } = new List<int>();
    }
}
