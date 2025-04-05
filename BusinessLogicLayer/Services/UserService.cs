using BusinessLogicLayer.Services.IService;
using DataAccessLayer.Entities;
using DataAccessLayer.Repositories.Bases;

namespace BusinessLogicLayer.Services
{
    public class UserService : IUser
    {
        private static UserService _Instance = null!;

        private readonly IUserRepo _UserRepository;

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

            return users.FirstOrDefault(user => user.Username == email && user.Password == password && user.IsActive);
        }

        public bool Delete(int id)
        {
            return false;
        }

        public User? Get(int id)
        {
            return null!;
        }

        public User? GetByUserName (string username)
        {
            return _UserRepository.GetByUserName(username);
        }

        public List<User> GetAll()
        {
            return _UserRepository.GetAll();
        }

        public List<User> GetAllByRoleId(int roleId)
        {
            var users = _UserRepository.GetAll()
                .Where(user => user.RoleId == roleId) // Only get customers
                .Select(user => new User
                {
                    Username = user.Username,
                    Fullname = user.Fullname,
                    IsActive = user.IsActive,
                    Gender = user.Gender,
                    RoleId = user.RoleId,
                    TypeOfSkinId = user.TypeOfSkinId,
                    TypeOfSkin = new TypeOfSkin { Name = user.TypeOfSkin.Name },
                    Role = new Role { Name = user.Role.Name }
                })
                .ToList();

            return users ?? new List<User>();
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
            return _UserRepository.Update(data);
        }

        public bool DeleteByUsername(string username)
        {
            return _UserRepository.DeleteByUsername(username);
        }
    }
}
