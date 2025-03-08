using BusinessLogicLayer.Dtos;
using BusinessLogicLayer.Services.IService;
using DataAccessLayer.Entities;
using DataAccessLayer.Repositories.IRepositories;

namespace BusinessLogicLayer.Services
{
    public class UserService : IService<UserDto>
    {
        private readonly IRepository<User> _UserRepository;

        public UserService()
        {
            _UserRepository = new UserRepository();
        }

        public UserDto Add(UserDto data)
        {
            return null!;
        }

        public bool Delete(int id)
        {
            return false;
        }

        public UserDto? Get(int id)
        {
            return null;
        }

        public List<UserDto> GetAll()
        {
            return [];
        }

        public UserDto? Update(UserDto data)
        {
            return null;
        }
    }
}
