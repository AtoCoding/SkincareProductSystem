using BusinessLogicLayer.Services.IService;
using DataAccessLayer.Entities;
using DataAccessLayer.Repositories.IRepositories;

namespace BusinessLogicLayer.Services
{
    public class UserService : IUser
    {
        private static UserService _Instance = null!;

        private readonly IRepository<User> _UserRepository;

        public UserService()
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

        public List<User> GetAllByRoleId(int roleId)
        {
            var users = _UserRepository.GetAll();

            if (users == null || users.Count == 0)
            {
                return new List<User>(); // Return empty list instead of null
            }

            return users.Where(user => user.RoleId == roleId).ToList();
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

        public bool Update(User user)
        {
            //var existingUser = _UserRepository.GetById(user.Username);
            //if (existingUser == null) return false;

            //// Update all relevant fields
            //existingUser.Username = user.Username;
            //existingUser.Fullname = user.Fullname;
            //existingUser.IsActive = user.IsActive;
            //existingUser.Gender = user.Gender;

            //return _UserRepository.Update(existingUser);
            return false;
        }

    }
}
