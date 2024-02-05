namespace VitaminBad.Data.Interface
{
    public interface IBaseRepository<T>
    {
        Task<bool> Create(T entity);
        Task<T> Get(Guid id);
        IQueryable<T> Select();
        Task<bool> Delete(T entity);
        Task<T> Update(T entity);
    }
}
