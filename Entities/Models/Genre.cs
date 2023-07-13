﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Models
{
    public class Genre
    {
        public int GenreId { get; set; }
        public string? Name { get; set; }

       public ICollection<GameGenre> GameGenres { get;set; } = new List<GameGenre>();
    }
}