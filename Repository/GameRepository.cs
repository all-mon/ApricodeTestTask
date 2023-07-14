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
                    var genre = ApplicationContext.Genres.First(g => g.Id == genresId);
                    if (genre is not null)
                    {
                        game.Genres?.Add(genre);
                    }
                }
            }       
        }
        public void CreateGame(Game game) => Create(game);
        public IEnumerable<Game> GetAllGames() => GetAll().Include(g => g.Genres).ToList();
        public Game? GetById(int id) => FindByCondition(g => g.Id.Equals(id)).Include(g => g.Genres).Single();
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

            if (genresIds == null)
            {
                gameToUpdate!.GameGenres = new List<GameGenre>();
                return;
            }

            var selectedGenresHS = new HashSet<int>(genresIds);
            var devicePlacementsHS = new HashSet<int>(gameToUpdate.GameGenres.Select(p => p.Genre.Id));

            foreach (var genre in ApplicationContext.Genres)
            {
                if (selectedGenresHS.Contains(genre.Id))
                {
                    if (!devicePlacementsHS.Contains(genre.Id))
                    {
                        gameToUpdate.GameGenres!.Add(new GameGenre
                        {
                            GenreId = genre.Id,
                            GameId = gameToUpdate.Id
                        });
                    }
                }
                else
                {
                    if (devicePlacementsHS.Contains(genre.Id))
                    {
                        GameGenre ggToRemove = gameToUpdate.GameGenres!
                            .FirstOrDefault(i => i.GameId == genre.Id)!;
                        ApplicationContext.Remove(ggToRemove!);
                    }
                }
            }

        }
    }
}
