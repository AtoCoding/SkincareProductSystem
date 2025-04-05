using DataAccessLayer;
using DataAccessLayer.Entities;
using DataAccessLayer.Repositories.Bases;
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

        public bool DeleteByUsername(string username)
        {
            User? user = _SkincareProductSystemContext.Users.FirstOrDefault(x => x.Username.Equals(username));

            _SkincareProductSystemContext.Users.Remove(user ?? new());

            return _SkincareProductSystemContext.SaveChanges() > 0;
        }

        public User? Get(int id)
        {
            return null;
        }

        public List<User> GetAll()
        {
            return _SkincareProductSystemContext.Users
                .Include(user => user.TypeOfSkin)
                .Include(user => user.Role)
                .ToList();
        }

        public User? GetByUserName(string username)
        {
            return _SkincareProductSystemContext.Users
                .Include (user => user.TypeOfSkin)
                .Include(user => user.Role)
                .FirstOrDefault(user => user.Username.Equals(username));
        }

        public List<User> Search(string? keyword)
        {
            return [];
        }

        public bool Update(User data)
        {
            return _SkincareProductSystemContext.SaveChanges() > 0;
        }
    }
}
