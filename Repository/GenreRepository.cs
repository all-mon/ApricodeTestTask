using Contracts;
using Entities;
using Entities.Models;

namespace Repository
{
    public class GenreRepository : RepositoryBase<Genre>, IGenreRepository
    {
        public GenreRepository(ApplicationContext applicationContext) : base(applicationContext)
        {
        }
    }
}
