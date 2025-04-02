namespace DataAccessLayer.Repositories.IRepositories
{
    public interface IRepository<T>
    {
        bool Add(T data);
        bool Update(T data);
        bool Delete(int id);
        T? Get(int id);
        List<T> GetAll();
        List<T> Search(string? keyword);

        // product management 
        //List<T> GetAllWithBrandAndCategory();
    }
}
