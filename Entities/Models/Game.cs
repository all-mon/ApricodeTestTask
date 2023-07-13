using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Models
{
    public class Game
    {
        public int GameId { get; set; }
        public string? Name { get; set; }
        public string? Studio { get; set; }
        public ICollection<GameGenre> GameGenres { get; set; } = new List<GameGenre>();
    }
}
