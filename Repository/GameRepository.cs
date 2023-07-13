using Contracts;
using Entities;
using Entities.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository
{
    public class GameRepository : RepositoryBase<Game>, IGameRepository
    {
        public GameRepository(ApplicationContext applicationContext):base(applicationContext) { }

        public IEnumerable<Game> GetAllGames()
        {
            return GetAll().Include(g => g.Genres).ToList();
                
        }
    }
}
