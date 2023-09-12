namespace Citel.Interface
{
    public interface IRepository<T>
    {
        Task<IEnumerable<T>> GetAll(CancellationToken cancellationToken);
        Task<T?> Get(int id, CancellationToken cancellationToken = default);
        Task Add(T item, CancellationToken cancellationToken);
        Task Edit(T item, CancellationToken cancellationToken);
        Task Delete(int id, CancellationToken cancellationToken);
    }
}
