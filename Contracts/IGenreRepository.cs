using Entities.Models;

namespace Contracts
{
    public interface IGenreRepository : IRepositoryBase<Genre>
    {
        Genre? GetById(int id);
    }
}
