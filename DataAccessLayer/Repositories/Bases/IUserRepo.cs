using DataAccessLayer.Entities;
using DataAccessLayer.Repositories.IRepositories;

namespace DataAccessLayer.Repositories.Bases
{
    public interface IUserRepo : IRepository<User>
    {
        User? GetByUserName(string username);
        bool DeleteByUsername(string username);

    }
    
}
