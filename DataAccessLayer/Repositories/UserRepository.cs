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

        public bool DeleteByUsername(string username)
        {
            using (var context = new SkincareProductSystemContext())
            {
                var user = context.Users.FirstOrDefault(u => u.Username == username);
                if (user == null)
                {
                    return false;
                }

                var orders = context.Orders.Where(o => o.Username == username).ToList();
                context.Orders.RemoveRange(orders);

                var brands = context.Brands.Where(b => b.Username == username).ToList();
                context.Brands.RemoveRange(brands);

                var categories = context.Categories.Where(c => c.Username == username).ToList();
                context.Categories.RemoveRange(categories);

                var products = context.SkincareProducts.Where(p => p.Username == username).ToList();
                context.SkincareProducts.RemoveRange(products);

                context.Users.Remove(user);
                context.SaveChanges();
                return true;
            }
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
        public bool IsUsernameExists(string username)
        {
            using (var context = new SkincareProductSystemContext())
            {
                return context.Users.Any(u => u.Username.ToLower() == username.ToLower());
            }
        }
    }
}
