using DataAccessLayer;
using DataAccessLayer.Entities;
using DataAccessLayer.Repositories.Bases;
using DataAccessLayer.Repositories.IRepositories;
using Microsoft.EntityFrameworkCore;

namespace BusinessLogicLayer.Services
{
    public class UserRepository : IUserRepo
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

        public User? Get(int id)
        {
            return null;
        }

        public List<User> GetAll()
        {
            return _SkincareProductSystemContext.Users.ToList();
        }

        public User? GetByUserName(string username)
        {
            return _SkincareProductSystemContext.Users.FirstOrDefault(user => user.Username.Equals(username));
        }

        public List<User> Search(string? keyword)
        {
            return [];
        }

        public bool Update(User data)
        {
            _SkincareProductSystemContext.Users.Update(data);

            return _SkincareProductSystemContext.SaveChanges() > 0;
        }
    }
}
