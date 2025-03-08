namespace BusinessLogicLayer.Services.IService
{
    public interface IService<T>
    {
        T Add(T data);
        T? Update(T data);
        bool Delete(int id);
        T? Get(int id);
        List<T> GetAll();
    }
}
