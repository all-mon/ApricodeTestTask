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

        public Genre? GetById(int id) => FindByCondition(g=>g.Id.Equals(id)).FirstOrDefault();
        
    }
}
