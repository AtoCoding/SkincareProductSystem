using DataAccessLayer.Entities;

namespace BusinessLogicLayer.Services.IService
{
    public interface IUser : IService<User>
    {
        User? CheckLogin(string email, string password);
        bool RegisterNewAccount(User user);
        User? GetByUserName(string username);
    }
}
