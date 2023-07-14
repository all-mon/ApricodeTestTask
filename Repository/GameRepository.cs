using Contracts;
using Entities;
using Entities.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;

namespace Repository
{
    public class GameRepository : RepositoryBase<Game>, IGameRepository
    {
        public GameRepository(ApplicationContext applicationContext) : base(applicationContext) { }
        public void AddGenres(Game game, IEnumerable<int>? genresIds)
        {
            if (!genresIds.IsNullOrEmpty())
            {
                foreach (int genresId in genresIds!)
                {
                    var genre = ApplicationContext.Genres.First(g => g.Id == genresId);
                    if (genre is not null)
                    {
                        game.Genres?.Add(genre);
                    }
                }
            }
        }
        public void CreateGame(Game game) => Create(game);

        public void DeleteGame(Game game) => Delete(game);
        
        public IEnumerable<Game> GetAllGames() => GetAll().Include(g => g.Genres).ToList();
        public Game? GetById(int id) => ApplicationContext.Games
            .Include(g => g.GameGenres)
                .ThenInclude(gg => gg.Genre)
            .FirstOrDefault(g => g.Id == id);
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

        public void UpdateGenres(Game gameToUpdate, IEnumerable<int>? genresIds)
        {
            //todo 

            if (genresIds.IsNullOrEmpty())
            {
                gameToUpdate.GameGenres.Clear();
                return;
            }

            gameToUpdate.GameGenres.Clear();

            foreach (int genresId in genresIds!)
            {
                gameToUpdate.GameGenres.Add(new GameGenre
                {
                    GameId = gameToUpdate.Id,
                    GenreId = genresId
                });
            }
        }
    }
}
