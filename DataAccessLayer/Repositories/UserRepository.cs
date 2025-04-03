using DataAccessLayer;
using DataAccessLayer.Entities;
using DataAccessLayer.Repositories.IRepositories;

namespace BusinessLogicLayer.Services
{
    public class UserRepository : IUserRepository
    {
        private static UserRepository _Instance = null!;

        private readonly SkincareProductSystemContext _SkincareProductSystemContext;

        private UserRepository()
        {
            _SkincareProductSystemContext = new();
        }

        public static UserRepository GetInstance() => _Instance ??= new UserRepository();

        public bool Add(User data)
        {
            _SkincareProductSystemContext.Users.Add(data);

            return _SkincareProductSystemContext.SaveChanges() > 0;
        }

        public bool Delete(int id)
        {
            return false;
        }

        public User GetByUserName(string username)
        {
           var user = _SkincareProductSystemContext.Users.FirstOrDefault(user => user.Username == username);
            if (user == null)
            {
                throw new Exception("User not found");
            }
            return user;
        }

        public List<User> GetAll()
        {
            return _SkincareProductSystemContext.Users.ToList();
        }

        public List<User> Search(string? keyword)
        {
            return [];
        }

        public bool Update(User data)
        {
            var existingUser = _SkincareProductSystemContext.Users.FirstOrDefault(u => u.Username == data.Username);

            if (existingUser == null)
            {
                return false; // User not found
            }

            // Update user properties
            existingUser.Username = data.Username;
            existingUser.Fullname = data.Fullname;
            existingUser.IsActive = data.IsActive;
            existingUser.Gender = data.Gender;
            existingUser.RoleId = data.RoleId;
            existingUser.TypeOfSkinId = data.TypeOfSkinId;

            // Save changes to the database
            return _SkincareProductSystemContext.SaveChanges() > 0;
        }
    }
}
