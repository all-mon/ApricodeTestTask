using Contracts;
using Entities;
using Entities.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;

namespace Repository
{
    public class GameRepository : RepositoryBase<Game>, IGameRepository
    {
        public GameRepository(ApplicationContext applicationContext):base(applicationContext) { }
        public void AddGenres(Game game, IEnumerable<int>? genresIds)
        {
            if (!genresIds.IsNullOrEmpty())
            {
                foreach (int genresId in genresIds!)
                {
                    var genre = ApplicationContext.Genres.First(g => g.GenreId == genresId);
                    if (genre is not null)
                    {
                        game.Genres?.Add(genre);
                    }
                }
            }       
        }
        public void CreateGame(Game game) => Create(game);
        public IEnumerable<Game> GetAllGames() => GetAll().Include(g => g.Genres).ToList();
        public Game? GetById(int id) => FindByCondition(g => g.GameId.Equals(id)).Include(g => g.Genres).FirstOrDefault();
        public void UpdateGame(Game game)
        {
            try
            {
                
                Update(game);
            }
            catch (Exception)
            {

                throw;
            }
            
        }

        public void UpdateGenres(Game game, IEnumerable<int>? genresIds)
        {
            if (!genresIds.IsNullOrEmpty())
            {
                foreach (int genresId in genresIds!)
                {
                    var genre = ApplicationContext.Genres.Where(s => s.GenreId == genresId).AsNoTracking().FirstOrDefault();
                    if (genre is not null)
                    {
                        if (!game.Genres.Contains(genre))
                        {
                            game.Genres.Add(genre);
                        }                     
                    }
                }
            }
        }
    }
}
