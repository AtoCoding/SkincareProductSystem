using BusinessLogicLayer.Services.IService;
using DataAccessLayer.Entities;
using DataAccessLayer.Repositories.Bases;

namespace BusinessLogicLayer.Services
{
    public class UserService : IUser
    {
        private static UserService _Instance = null!;

        private readonly IUserRepo _UserRepository;

        private readonly UserRepository _userRepository;


        private UserService()
        {
            _UserRepository = UserRepository.GetInstance();

            _userRepository = UserRepository.GetInstance();
        }

        public static UserService GetInstance() => _Instance ??= new UserService();

        public bool Add(User data)
        {
            return _UserRepository.Add(data);
        }

        public User? CheckLogin(string email, string password)
        {
            List<User> users = _UserRepository.GetAll();

            return users.FirstOrDefault(user => user.Username == email && user.Password == password);
        }

        public bool DeleteByUsername(string username)
        {
            return _UserRepository.DeleteByUsername(username);
        }

        public User? Get(int id)
        {
            return _UserRepository.Get(id);
        }

        public User? GetByUserName (string username)
        {
            return _UserRepository.GetByUserName(username);
        }

        public List<User> GetAll() => _UserRepository.GetAll();


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

        public List<User> Search(string? keyword) => _UserRepository.Search(keyword);


        public bool Update(User data)
        {
            return _UserRepository.Update(data);
        }
        public bool IsUsernameExists(string username)
        {
            return _userRepository.IsUsernameExists(username); 
        }

        public bool Delete(int id)
        {
            return _userRepository.Delete(id);
        }
    }
}
