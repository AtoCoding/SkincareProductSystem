namespace BusinessLogicLayer.Services.IService
{
    public interface IService<T>
    {
        bool Add(T data);
        bool Update(T data);
        bool Delete(int id);
        T? Get(int id);
        List<T> GetAll();
        List<T> Search(string? keyword);
    }
}
