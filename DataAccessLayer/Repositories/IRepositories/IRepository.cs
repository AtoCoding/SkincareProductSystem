namespace DataAccessLayer.Repositories.IRepositories
{
    public interface IRepository<T>
    {
        T Add(T data);
        T? Update(T data);
        bool Delete(int id);
        T? Get(int id);
        List<T> GetAll();
        List<T> Search(string? keyword);
    }
}
