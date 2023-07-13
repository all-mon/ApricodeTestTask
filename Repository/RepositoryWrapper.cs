using Contracts;
using Entities;

namespace Repository
{
    public class RepositoryWrapper : IRepositoryWrapper
    {
        private ApplicationContext _context;
        private IGameRepository _game;
        private IGenreRepository _genre;
        public IGameRepository Game 
        {
            get 
            { 
                if (_game == null) 
                {
                    _game = new GameRepository(_context); 
                }
                return _game;
            }
        }

        public IGenreRepository Genre
        {
            get
            {
                if ( _genre == null)
                {
                    _genre = new GenreRepository(_context);
                }
                return _genre;
            }
        }

        public RepositoryWrapper(ApplicationContext context)
        {
            _context = context;
        }

        public void Save()
        {
           _context.SaveChanges();
        }
    }
}
