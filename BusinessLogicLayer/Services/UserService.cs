using BusinessLogicLayer.Services.IService;
using DataAccessLayer.Entities;
using DataAccessLayer.Repositories.IRepositories;

namespace BusinessLogicLayer.Services
{
    public class UserService : IUser
    {
        private static UserService _Instance = null!;
        private readonly IRepository<User> _UserRepository;

        private UserService()
        {
            _UserRepository = UserRepository.GetInstance();
        }

        public static UserService GetInstance() => _Instance ??= new UserService();

        public bool Add(User data)
        {
            return false;
        }

        public User? CheckLogin(string email, string password)
        {
            List<User> users = _UserRepository.GetAll();

            return users.FirstOrDefault(user => user.Username == email && user.Password == password);
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
            return _UserRepository.GetAll();
        }

        public bool RegisterNewAccount(User user)
        {
            if (user != null)
            {
                user.IsActive = true;
                user.RoleId = 3;
                user.TypeOfSkinId = 1;
                return _UserRepository.Add(user);
            }

            return false;
        }

        public List<User> Search(string? keyword)
        {
            return [];
        }

        public bool Update(User data)
        {
            return false;
        }
    }
}
