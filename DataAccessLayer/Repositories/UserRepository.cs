using DataAccessLayer;
using DataAccessLayer.Entities;
using DataAccessLayer.Repositories.IRepositories;

namespace BusinessLogicLayer.Services
{
    public class UserRepository : IRepository<User>
    {
        private readonly SkincareProductSystemContext _SkincareProductSystemContext;

        public UserRepository()
        {
            _SkincareProductSystemContext = new();
        }

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

        public User? Update(User data)
        {
            return null;
        }
    }
}
