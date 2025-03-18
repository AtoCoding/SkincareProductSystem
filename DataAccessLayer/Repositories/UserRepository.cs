using DataAccessLayer;
using DataAccessLayer.Entities;
using DataAccessLayer.Repositories.IRepositories;

namespace BusinessLogicLayer.Services
{
    public class UserRepository : IRepository<User>
    {
        private static UserRepository _Instance = null!;
        private readonly SkincareProductSystemContext _SkincareProductSystemContext;

        private UserRepository()
        {
            _SkincareProductSystemContext = new();
        }

        public static UserRepository GetInstance() => _Instance ??= new UserRepository();

        public User Add(User data)
        {
            return null!;
        }

        public bool Delete(int id)
        {
            return false;
        }

        public User? Get(int id)
        {
            return null;
        }

        public List<User> GetAll()
        {
            return [];
        }

        public List<User> Search(string? keyword)
        {
            return [];
        }

        public User? Update(User data)
        {
            return null;
        }
    }
}
