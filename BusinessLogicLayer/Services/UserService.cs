using BusinessLogicLayer.Dtos;
using BusinessLogicLayer.Services.IService;
using DataAccessLayer.Entities;
using DataAccessLayer.Repositories.IRepositories;

namespace BusinessLogicLayer.Services
{
    public class UserService : IService<UserDto>
    {
        private static UserService _Instance = null!;
        private readonly IRepository<User> _UserRepository;

        private UserService()
        {
            _UserRepository = UserRepository.GetInstance();
        }

        public static UserService GetInstance() => _Instance ??= new UserService();

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

        public List<UserDto> Search(string? keyword)
        {
            return [];
        }

        public UserDto? Update(UserDto data)
        {
            return null;
        }
    }
}
