using BusinessLogicLayer.Services.IService;
using DataAccessLayer.Entities;
using DataAccessLayer.Repositories.IRepositories;

namespace BusinessLogicLayer.Services
{
    public class RoleService : IService<Role>
    {
        private static RoleService _Instance = null!;

        private readonly IRepository<Role> _RoleRepository;

        private RoleService()
        {
            _RoleRepository = RoleRepository.GetInstance();
        }

        public static RoleService GetInstance() => _Instance ??= new RoleService();

        public bool Add(Role data)
        {
            return false;
        }

        public bool Delete(int id)
        {
            return false;
        }

        public Role? Get(int id)
        {
            return null;
        }

        public List<Role> GetAll()
        {
            return _RoleRepository.GetAll();
        }

        public List<Role> Search(string? keyword)
        {
            return [];
        }

        public bool Update(Role data)
        {
            return false;
        }
    }
}
