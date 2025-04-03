using DataAccessLayer;
using DataAccessLayer.Entities;
using DataAccessLayer.Repositories.IRepositories;
using Microsoft.EntityFrameworkCore;

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
            return _SkincareProductSystemContext.Users
                .Include(user => user.TypeOfSkin)
                .Include(user => user.Role)
                .ToList();
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
