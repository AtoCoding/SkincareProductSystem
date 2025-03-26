using BusinessLogicLayer.Services.IService;
using DataAccessLayer.Entities;
using DataAccessLayer.Repositories.IRepositories;

namespace BusinessLogicLayer.Services
{
    public class UserService : IService<User>
    {
        private static UserService _Instance = null!;
        private readonly IRepository<User> _UserRepository;

        private UserService()
        {
            _UserRepository = UserRepository.GetInstance();
        }

        public static UserService GetInstance() => _Instance ??= new UserService();

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
