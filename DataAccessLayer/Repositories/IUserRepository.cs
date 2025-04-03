using DataAccessLayer;
using DataAccessLayer.Entities;
using DataAccessLayer.Repositories.IRepositories;

namespace BusinessLogicLayer.Services
{
    public interface IUserRepository
    {

        public bool Add(User data);

        public bool Delete(int id);

        public User GetByUserName(string username);

        public List<User> GetAll();

        public List<User> Search(string? keyword);

        public bool Update(User data);
    }
}
