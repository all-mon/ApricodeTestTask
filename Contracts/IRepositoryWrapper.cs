namespace Contracts
{
    public interface IRepositoryWrapper
    {
        IGameRepository Game { get; }
        IGenreRepository Genre { get; }
        void Save();
    }
}
