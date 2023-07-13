using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.DTO
{
    public class GameForCreationDto
    {
        public string? Name { get; set; }
        public string? Studio { get; set; }
        public ICollection<int> GenresIds { get; set; } = new List<int>();
    }
}
