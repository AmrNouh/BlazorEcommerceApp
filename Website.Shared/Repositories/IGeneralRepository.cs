namespace Website.Shared.Repositories
{
    public interface IGeneralRepository<T>
    {
        Task<List<T>> GetAllAsync();
        Task<T> GetByIdAsync(int id);
        Task<int> UpdateAsync(int id,T entity);
        Task<int> DeleteAsync(int id);
        Task<int> InsertAsync(T entity);

    }
}