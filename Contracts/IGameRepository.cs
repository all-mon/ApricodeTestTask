using Entities.Models;

namespace Contracts
{
    public interface IGameRepository : IRepositoryBase<Game>
    {
        IEnumerable<Game> GetAllGames();
        Game? GetById(int id);
        void AddGenres(Game game, IEnumerable<int>? genresIds);
        void UpdateGenres(Game game, IEnumerable<int>? genresIds);
        void CreateGame(Game game);
        void UpdateGame(Game game);
    }
}
